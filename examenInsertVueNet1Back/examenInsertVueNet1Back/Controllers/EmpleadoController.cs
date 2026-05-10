using examenInsertVueNet1Back.Context;
using examenInsertVueNet1Back.DTOs;
using examenInsertVueNet1Back.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace examenInsertVueNet1Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly ExamenInsertVueNet1Context _context;
        public EmpleadoController(ExamenInsertVueNet1Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("ListaEmpleados")]
        public async Task<ActionResult<IEnumerable<EmpleadoDTO>>> ListarEmpleados(int idDep=0)
        {
            try
            {
                var empleadosBD = new List<Empleado>();
                if (idDep == 0)
                {
                    empleadosBD = await _context.Empleados.Include(e => e.IdDepartamentoNavigation).ToListAsync();
                }
                else
                {
                    empleadosBD = await _context.Empleados.FromSqlRaw("EXEC sp_ListarEmpleadosPorIdDep {0}", idDep).ToListAsync();
                    foreach ( var emp in empleadosBD)
                    {
                        await _context.Entry(emp).Reference(e => e.IdDepartamentoNavigation).LoadAsync();
                    }
                }
                var listaDTO = empleadosBD.Select(e => new EmpleadoDTO
                {
                    IdEmpleado = e.IdEmpleado,
                    NombreEmpleado = e.NombreEmpleado ?? string.Empty,
                    IdDepartamento = e.IdDepartamento,
                    NombreDepartamento = e.IdDepartamentoNavigation?.NombreDepartamento ?? "Sin Asignar"
                });
                return Ok(listaDTO);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("GuardarEmpleado")]
        public async Task<ActionResult<EmpleadoDTO>> GuardarEmpleado(EmpleadoDTO empleadoDTO)
        {

            try
            {
                var empleadoBD = new Empleado
                {
                    NombreEmpleado = empleadoDTO.NombreEmpleado,
                    IdDepartamento = empleadoDTO.IdDepartamento
                };

                await _context.AddAsync(empleadoBD);
                await _context.SaveChangesAsync();

                empleadoDTO.IdEmpleado = empleadoBD.IdEmpleado;

                return Ok(empleadoDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
