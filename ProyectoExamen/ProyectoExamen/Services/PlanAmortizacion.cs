using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoExamen.Entities;
using ProyectoExamen.Dtos;
using ProyectoExamen.Services.Interfaces;
using ProyectoExamen.Database.Entities;

namespace ProyectoExamen.Services.Implementaciones
{
    public class PlanAmortizacionService : IPlanAmortizacionService
    {
        private readonly ApiDbContext _context;

        public PlanAmortizacionService(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<List<PlanAmortizacion>> GenerarPlanAmortizacionAsync(Prestamo prestamo)
        {
            var planAmortizacion = new List<PlanAmortizacion>();
            decimal saldoPrincipal = prestamo.Monto;
            decimal tasaInteresMensual = prestamo.TasaInteres / 100 / 12; 
            decimal cuotaNivelada = CalcularCuotaNivelada(prestamo.Monto, tasaInteresMensual, prestamo.Plazo);

            DateTime fechaPago = prestamo.FechaPrimerPago;

            for (int i = 1; i <= prestamo.Plazo; i++)
            {
                int dias = (i == 1) ? (fechaPago - prestamo.FechaDesembolso).Days : 30;

                decimal interes = saldoPrincipal * tasaInteresMensual; 
                decimal principal = cuotaNivelada - interes; 
                decimal saldoAnterior = saldoPrincipal; 

                var amortizacion = new PlanAmortizacion
                {
                    PrestamoId = prestamo.Id,
                    NumeroCuota = i,
                    FechaPago = fechaPago,
                    Dias = dias,
                    Interes = Math.Round(interes, 2),
                    Principal = Math.Round(principal, 2),
                    SaldoPrincipal = Math.Round(saldoPrincipal - principal, 2)
                };

                planAmortizacion.Add(amortizacion);
              
                saldoPrincipal -= principal;

                fechaPago = fechaPago.AddMonths(1);
            }

            await GuardarPlanAmortizacion(planAmortizacion);

            return planAmortizacion; 
        }

        private decimal CalcularCuotaNivelada(decimal monto, decimal tasaInteresMensual, int plazo)
        {
            throw new NotImplementedException();
        }

        Task<PlanAmortizacion> IPlanAmortizacionService.GenerarPlanAmortizacionAsync(Prestamo prestamo)
        {
            throw new NotImplementedException();
        }

        private async Task GuardarPlanAmortizacion(List<PlanAmortizacion> planAmortizacion)
        {
            await _context.PlanesAmortizacion.AddRangeAsync(planAmortizacion);
            await _context.SaveChangesAsync();
        }
    }
}