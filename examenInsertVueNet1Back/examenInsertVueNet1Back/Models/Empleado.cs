using System;
using System.Collections.Generic;

namespace examenInsertVueNet1Back.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string? NombreEmpleado { get; set; }

    public int? IdDepartamento { get; set; }

    public virtual Departamento? IdDepartamentoNavigation { get; set; }
}
