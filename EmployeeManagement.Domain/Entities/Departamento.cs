using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Domain.Entities
{
    public class Departamento
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; }
        public string Descripcion { get; private set; }
        public bool Activo { get; private set; }

        private Departamento()
        {
            Nombre = string.Empty;
            Descripcion = string.Empty;
        }

        public Departamento(string nombre, string descripcion)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException(
                    "El nombre del departamento es obligatorio.");

            Id = Guid.NewGuid();
            Nombre = nombre.Trim();
            Descripcion = descripcion?.Trim() ?? string.Empty;
            Activo = true;
        }

        public void Actualizar(string nombre, string descripcion)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException(
                    "El nombre del departamento es obligatorio.");

            Nombre = nombre.Trim();
            Descripcion = descripcion?.Trim() ?? string.Empty;
        }

        public void Desactivar()
        {
            if (!Activo)
                throw new InvalidOperationException(
                    "El departamento ya está inactivo.");

            Activo = false;
        }

        public void Activar()
        {
            if (Activo)
                throw new InvalidOperationException(
                    "El departamento ya está activo.");

            Activo = true;
        }
    }
}
