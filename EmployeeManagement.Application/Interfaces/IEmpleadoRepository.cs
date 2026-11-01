using EmployeeManagement.Application.DTOs.Empleados;
using EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.Interfaces
{
    public interface IEmpleadoRepository
    {
        Task AddAsync(Empleado empleado, CancellationToken cancellationToken = default);

        Task<Empleado?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<bool> ExistsEmailAsync(string correo, CancellationToken cancellationToken = default);

        Task<List<Empleado>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}
