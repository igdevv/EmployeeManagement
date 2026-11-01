using EmployeeManagement.Application.DTOs.Empleados;
using EmployeeManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.Services
{
    public class ObtenerEmpleadosService
    {
        private readonly IEmpleadoRepository _repository;

        public ObtenerEmpleadosService(IEmpleadoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EmpleadoDto>> EjecutarAsync(CancellationToken cancellationToken = default)
        {
            var empleados = await _repository.GetAllAsync(cancellationToken);

            return empleados.Select(e => new EmpleadoDto
            {
                Id = e.Id,
                Nombre = e.Nombre,
                Apellido = e.Apellido,
                Correo = e.Correo,
                Salario = e.Salario,
                FechaContratacion = e.FechaContratacion,
                Activo = e.Activo,
                DepartamentoId = e.DepartamentoId,
                CargoId = e.CargoId
            }).ToList();
        }
    }
}
