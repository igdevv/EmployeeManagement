using EmployeeManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Empleado> Empleados => Set<Empleado>();
        public DbSet<Departamento> Departamentos => Set<Departamento>();
        public DbSet<Cargo> Cargos => Set<Cargo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación Empleado → Departamento
            modelBuilder.Entity<Empleado>()
                .HasOne<Departamento>()
                .WithMany()
                .HasForeignKey(e => e.DepartamentoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Empleado → Cargo
            modelBuilder.Entity<Empleado>()
                .HasOne<Cargo>()
                .WithMany()
                .HasForeignKey(e => e.CargoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Precisión del salario
            modelBuilder.Entity<Empleado>()
                .Property(e => e.Salario)
                .HasPrecision(18, 2);

            // Evitar correos duplicados
            modelBuilder.Entity<Empleado>()
                .HasIndex(e => e.Correo)
                .IsUnique();
        }

    }
}
