//namespace ProyectoExamen.Controllers
//{
//    public class LoanController
//    {
//    }
//}

using ProyectoExamen.Dtos;
using ProyectoExamen.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ProyectoExamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly IPrestamoService _prestamoService;

        public PrestamoController(IPrestamoService prestamoService)
        {
            _prestamoService = prestamoService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrestamo([FromBody] SolicitudPrestamo solicitudPrestamoDto)
        {
            await _prestamoService.CreatePrestamoAsync(solicitudPrestamoDto);
            return Ok(new { message = "El prestammo fue creado correctamente." });
        }

        [HttpGet("{clienteId}")]
        public async Task<IActionResult> GetPlan(int clienteId)
        {
            var PlanPrestamo = await _prestamoService.GetPlanByClienteIdAsync(clienteId);
            return Ok(PlanPrestamo);
        }
    }
}


