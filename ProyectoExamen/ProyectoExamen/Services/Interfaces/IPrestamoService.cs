using ProyectoExamen.Dtos;
using ProyectoExamen.Database.Entities;

namespace ProyectoExamen.Services.Interfaces
{
    public interface IPrestamoService
    {
        Task<Prestamo> CrearPrestamoAsync(PrestamoDto prestamoDto);
        Task<Prestamo> ObtenerPrestamoPorIdAsync(int id);
    }
}

