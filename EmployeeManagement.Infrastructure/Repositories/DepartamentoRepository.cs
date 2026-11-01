using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class DepartamentoRepository : IDepartamentoRepository
    {
        private readonly AppDbContext _dbContext;

        public DepartamentoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Departamento?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Departamentos.FirstOrDefaultAsync(d => d.Id == id, cancellationToken);
        }

        public async Task AddAsync(Departamento departamento, CancellationToken cancellationToken = default)
        {
            _dbContext.Departamentos.Add(departamento);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
