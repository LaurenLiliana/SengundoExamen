using ProyectoExamen.Dtos;
using ProyectoExamen.Database.Entities;

namespace ProyectoExamen.Services.Interfaces
{
    public interface IClienteService
    {
        Task<Cliente> CrearClienteAsync(ClienteDto clienteDto);
        Task<Cliente> ObtenerClientePorIdAsync(int id);
    }
}