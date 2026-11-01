using EmployeeManagement.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [ApiController]
    [Route("api/empleados")]
    public class EmpleadosController: ControllerBase
    {
        private readonly CrearEmpleadoService _crearEmpleadoService;
        private readonly ObtenerEmpleadosService _obtenerEmpleadosService;

        public EmpleadosController(CrearEmpleadoService crearEmpleadoService, ObtenerEmpleadosService obtenerEmpleadosService)
        {
            _crearEmpleadoService = crearEmpleadoService;
            _obtenerEmpleadosService = obtenerEmpleadosService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var empleados = await _obtenerEmpleadosService.EjecutarAsync(cancellationToken);

            return Ok(empleados);
        }
    }
}
