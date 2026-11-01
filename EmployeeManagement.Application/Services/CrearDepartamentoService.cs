using EmployeeManagement.Application.DTOs.Departamentos;
using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.Services
{
    public class CrearDepartamentoService
    {
        private readonly IDepartamentoRepository _departamentoRepository;

        public CrearDepartamentoService(IDepartamentoRepository departamentoRepository)
        {
            _departamentoRepository = departamentoRepository;
        }

        public async Task<Guid> EjecutarAsync(CrearDepartamentoDto dto, CancellationToken cancellationToken = default)
        {
            ArgumentNullException.ThrowIfNull(dto);

            var departamento = new Departamento(
                dto.Nombre,
                dto.Descripcion);

            await _departamentoRepository.AddAsync(departamento, cancellationToken);

            return departamento.Id;
        }
    }
}
