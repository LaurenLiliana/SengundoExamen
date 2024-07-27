using System.Threading.Tasks;
using ProyectoExamen.Entities;
using ProyectoExamen.Dtos;
using ProyectoExamen.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProyectoExamen.Database.Entities;

namespace ProyectoExamen.Services.Implementaciones
{
    public class ClienteService : IClienteService
    {
        private readonly ApiDbContext _context;

        public ClienteService(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente> CrearClienteAsync(ClienteDto clienteDto)
        {
            var cliente = new Cliente
            {
                Nombre = clienteDto.Nombre,
                NumeroIdentidad = clienteDto.NumeroIdentidad
            };

            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }

        public async Task<Cliente> ObtenerClientePorIdAsync(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<Cliente> ObtenerClientePorNumeroIdentidadAsync(string numeroIdentidad)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.NumeroIdentidad == numeroIdentidad);
        }
    }
}