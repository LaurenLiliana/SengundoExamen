using ProyectoExamen.Database.Entities;

namespace ProyectoExamen.Services.Interfaces
{
    public interface IPlanAmortizacionService
    {
        Task<PlanAmortizacion> GenerarPlanAmortizacionAsync(Prestamo prestamo);
    }
}
