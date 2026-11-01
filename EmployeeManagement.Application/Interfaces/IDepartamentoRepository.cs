using EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.Interfaces
{
    public interface IDepartamentoRepository
    {
        Task<Departamento?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task AddAsync(Departamento departamento, CancellationToken cancellationToken = default);
    }
}
