using EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Application.Interfaces
{
    public interface ICargoRepository
    {
        Task<Cargo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
