using examenInsertVueNet1Back.Context;
using examenInsertVueNet1Back.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace examenInsertVueNet1Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {

        private readonly ExamenInsertVueNet1Context _context;
        public DepartamentoController(ExamenInsertVueNet1Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("ListaDepartamentos")]
        public async Task<ActionResult<IEnumerable<DepartamentoDTO>>> ListarDepartamento()
        {
            try
            {
                var departamentosDTO = await _context.Departamentos
                    .Select(d => new DepartamentoDTO
                    {
                        IdDepartamento = d.IdDepartamento,
                        NombreDepartamento = d.NombreDepartamento ?? string.Empty
                    }).ToListAsync();
                return Ok(departamentosDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los departamentos: {ex.Message}");
            }
        }
    }
}
