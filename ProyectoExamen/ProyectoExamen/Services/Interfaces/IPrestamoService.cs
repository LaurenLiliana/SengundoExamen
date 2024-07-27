using ProyectoExamen.Dtos;

namespace ProyectoExamen.Services.Interfaces
{
    public interface IPrestamoService
    {
        Task CreatePrestamoAsync(SolicitudPrestamoDto solicitudPrestamoDto);
        Task<PlanDto> GetPlanByClienteIdAsync(int clienteId);
    }
}

