using EmployeeManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.UnitTests
{
    public class EmpleadoTests
    {
        [Fact]
        public void CrearEmpleado_ConSalarioNegativo_DebeLanzarExcepcion()
        {
            //Arrange
            decimal salario = -5000;

            //Act
            Action accion = () => new Empleado(
                "Carlos",
                "Martinez",
                "carlos@empresa.com",
                salario,
                DateTime.Today,
                Guid.NewGuid(),
                Guid.NewGuid()
            );

            //Assert
            Assert.Throws<ArgumentException>(accion);
        }
    }
}
