using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Domain.Entities
{
    public class Empleado
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; }
        public string Apellido { get; private set; }
        public string Correo { get; private set; }
        public decimal Salario { get; private set; }
        public DateTime FechaContratacion { get; private set; }
        public bool Activo { get; private set; }

        public Guid DepartamentoId { get; private set; }
        public Guid CargoId { get; private set; }

        private Empleado()
        {
            Nombre = string.Empty;
            Apellido = string.Empty;
            Correo = string.Empty;
        }

        public Empleado(
            string nombre,
            string apellido,
            string correo,
            decimal salario,
            DateTime fechaContratacion,
            Guid departamentoId,
            Guid cargoId)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre es obligatorio.");

            if (string.IsNullOrWhiteSpace(apellido))
                throw new ArgumentException("El apellido es obligatorio.");

            if (string.IsNullOrWhiteSpace(correo))
                throw new ArgumentException("El correo es obligatorio.");

            if (salario < 0)
                throw new ArgumentException("El salario no puede ser negativo.");

            if (departamentoId == Guid.Empty)
                throw new ArgumentException("El departamento es obligatorio.");

            if (cargoId == Guid.Empty)
                throw new ArgumentException("El cargo es obligatorio.");

            if (fechaContratacion == default)
                throw new ArgumentException("La fecha de contratación es obligatoria.");

            Id = Guid.NewGuid();
            Nombre = nombre.Trim();
            Apellido = apellido.Trim();
            Correo = correo.Trim();
            Salario = salario;
            FechaContratacion = fechaContratacion;
            DepartamentoId = departamentoId;
            CargoId = cargoId;
            Activo = true;
        }

        public void CambiarSalario(decimal nuevoSalario)
        {
            if (nuevoSalario < 0)
                throw new ArgumentException("El salario no puede ser negativo.");

            Salario = nuevoSalario;
        }

        public void CambiarDepartamento(Guid departamentoId)
        {
            if (departamentoId == Guid.Empty)
                throw new ArgumentException("El departamento es inválido.");

            DepartamentoId = departamentoId;
        }

        public void CambiarCargo(Guid cargoId)
        {
            if (cargoId == Guid.Empty)
                throw new ArgumentException("El cargo es inválido.");

            CargoId = cargoId;
        }

        public void Desactivar()
        {
            if (!Activo)
                throw new InvalidOperationException("El empleado ya está inactivo.");

            Activo = false;
        }

        public void Activar()
        {
            if (Activo)
                throw new InvalidOperationException("El empleado ya está activo.");

            Activo = true;
        }
    }
}
