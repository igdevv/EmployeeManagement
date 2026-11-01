using EmployeeManagement.Application.DTOs.Empleados;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.Services
{
    public class CrearEmpleadoService
    {
        private readonly IEmpleadoRepository _repository;
        private readonly IDepartamentoRepository _departamentoRepository;
        private readonly ICargoRepository _cargoRepository;

        public CrearEmpleadoService(IEmpleadoRepository repository, IDepartamentoRepository departamentoRepository,
            ICargoRepository cargoRepository)
        {
            _repository = repository;
            _departamentoRepository = departamentoRepository;
            _cargoRepository = cargoRepository;
        }

        public async Task<Guid> EjecutarAsync(CrearEmpleadoDto dto, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(dto.Correo))
                throw new ArgumentException("El correo es obligatorio.");

            var departamento = await _departamentoRepository.GetByIdAsync(
                dto.DepartamentoId, cancellationToken);

            if (departamento is null || !departamento.Activo)
                throw new InvalidOperationException(
                    "El departamento no existe o está inactivo.");

            var cargo = await _cargoRepository.GetByIdAsync(
                dto.CargoId, cancellationToken);

            if (cargo is null || !cargo.Activo)
                throw new InvalidOperationException(
                    "El cargo no existe o está inactivo.");

            var empleado = new Empleado(
                dto.Nombre,
                dto.Apellido,
                dto.Correo,
                dto.Salario,
                dto.FechaContratacion,
                dto.DepartamentoId,
                dto.CargoId
            );

            var existeCorreo = await _repository.ExistsEmailAsync(
                empleado.Correo,
                cancellationToken);

            if (existeCorreo)
                throw new InvalidOperationException(
                    "Ya existe un empleado con ese correo.");

            await _repository.AddAsync(
                empleado, cancellationToken);

            return empleado.Id;
        }
    }
}
