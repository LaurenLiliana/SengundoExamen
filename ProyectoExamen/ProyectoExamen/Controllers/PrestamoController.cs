using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ProyectoExamen.Dtos;
using ProyectoExamen.Services.Interfaces;

namespace ProyectoExamen.Controllers
{
    [ApiController]
    [Route("api/prestamos")]
    public class PrestamoController : ControllerBase
    {
        private readonly IPrestamoService _prestamoService;

        public PrestamoController(IPrestamoService prestamoService)
        {
            _prestamoService = prestamoService;
        }

        [HttpPost]
        public async Task<IActionResult> CrearPrestamo([FromBody] PrestamoDto prestamoDto)
        {
            var prestamo = await _prestamoService.CrearPrestamoAsync(prestamoDto);
            return CreatedAtAction(nameof(ObtenerPrestamoPorId), new { id = prestamo.Id }, prestamo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPrestamoPorId(int id)
        {
            var prestamo = await _prestamoService.ObtenerPrestamoPorIdAsync(id);
            if (prestamo == null)
            {
                return NotFound();
            }
            return Ok(prestamo);
        }
    }
}


