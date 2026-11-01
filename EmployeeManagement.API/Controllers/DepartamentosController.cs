using EmployeeManagement.Application.DTOs.Departamentos;
using EmployeeManagement.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [ApiController]
    [Route("api/departamentos")]
    public class DepartamentosController: ControllerBase
    {
        private readonly CrearDepartamentoService _departamentoService;

        public DepartamentosController(CrearDepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CrearDepartamentoDto dto, CancellationToken cancellationToken = default)
        {
            var id = await _departamentoService.EjecutarAsync(dto, cancellationToken);

            return Created($"api/departamentos/{id}", new { id });
        }
    }
}
