using EmployeeManagement.Application.Interfaces;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Infrastructure.Repositories
{
    public class EmpleadoRepository: IEmpleadoRepository
    {
        private readonly AppDbContext _dbContext;

        public EmpleadoRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Empleado empleado, CancellationToken cancellationToken = default)
        {
            await _dbContext.AddAsync(empleado, cancellationToken);

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> ExistsEmailAsync(string correo, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Empleados.AnyAsync(e => e.Correo == correo, cancellationToken);
        }

        public async Task<List<Empleado>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Empleados
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<Empleado?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Empleados.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
        }
    }
}
