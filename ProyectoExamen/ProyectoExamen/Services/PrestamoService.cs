using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoExamen.Entities;
using ProyectoExamen.Dtos;
using ProyectoExamen.Services.Interfaces;
using ProyectoExamen.Database.Entities;

namespace ProyectoExamen.Services.Implementaciones
{
    public class PrestamoService : IPrestamoService
    {
        private readonly ApiDbContext _context;
        private readonly IClienteService _clienteService;

        public PrestamoService(ApiDbContext context, IClienteService clienteService)
        {
            _context = context;
            _clienteService = clienteService;
        }

        public async Task<Prestamo> CrearPrestamoAsync(PrestamoDto prestamoDto)
        {
      
            var clienteDto = new ClienteDto
            {
                Nombre = prestamoDto.Cliente.Nombre,
                NumeroIdentidad = prestamoDto.Cliente.NumeroIdentidad
            };
            var cliente = await _clienteService.CrearClienteAsync(clienteDto);

            var prestamo = new Prestamo
            {
                ClienteId = cliente.Id,
                Monto = prestamoDto.Monto,
                TasaInteres = prestamoDto.TasaInteres,
                Plazo = prestamoDto.Plazo,
                FechaDesembolso = prestamoDto.FechaDesembolso,
                FechaPrimerPago = prestamoDto.FechaPrimerPago
            };

      
            _context.Prestamos.Add(prestamo);
            await _context.SaveChangesAsync();

            return prestamo; 
        }

        public async Task<Prestamo> ObtenerPrestamoPorIdAsync(int id)
        {
            return await _context.Prestamos
                .Include(p => p.Cliente)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}