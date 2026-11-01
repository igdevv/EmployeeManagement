using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class CargoRepository : ICargoRepository
    {
        private readonly AppDbContext _dbContext;

        public CargoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Cargo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Cargos.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
        }
    }
}
