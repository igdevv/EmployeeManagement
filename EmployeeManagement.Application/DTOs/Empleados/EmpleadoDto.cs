using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.DTOs.Empleados
{
    public class EmpleadoDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public decimal Salario { get; set; }
        public DateTime FechaContratacion { get; set; }
        public bool Activo { get; set; }
        public Guid DepartamentoId { get; set; }
        public Guid CargoId { get; set; }
    }
}
