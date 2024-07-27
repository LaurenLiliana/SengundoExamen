using ProyectoExamen.Dtos;
using ProyectoExamen.Entities;
using ProyectoExamen.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProyectoExamen.Database.Entities;
using ProyectoExamen.Entities;

namespace ProyectoExamen.Services
{
    public class PrestamoService : IPrestamoService
    {
        private readonly ApiDbContext _context;

        public PrestamoService(ApiDbContext context)
        {
            _context = context;
        }

        public async Task CreatePrestamoAsync(SolicitudPrestamoDto solicitudPrestamoDto)
        {
            // Crear cliente
            var cliente = new Cliente
            {
                Nombre = solicitudPrestamoDto.Nombre,
                NumeroId = solicitudPrestamoDto.NumeroId
            };
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            // Crear préstamo
            var prestamo = new Prestamo
            {
                ClientId = cliente.Id,
                LoanAmount = solicitudPrestamoDto.LoanAmount,
                CommissionRate = solicitudPrestamoDto.CommissionRate,
                InterestRate = solicitudPrestamoDto.InterestRate,
                Term = solicitudPrestamoDto.Term,
                DisbursementDate = solicitudPrestamoDto.DisbursementDate,
                FirstPaymentDate = solicitudPrestamoDto.FirstPaymentDate
            };
            _context.Loans.Add(prestamo);
            await _context.SaveChangesAsync();

            // Calcular plan de amortización y guardar en la base de datos
            var amortizationPlan = CalculateAmortizationPlan(prestamo);
            foreach (var installment in amortizationPlan)
            {
                _context.AmortizationPlans.Add(new AmortizationPlan
                {
                    LoanId = prestamo.Id,
                    InstallmentNumber = installment.InstallmentNumber,
                    PaymentDate = installment.PaymentDate,
                    Days = installment.Days,
                    Interest = installment.Interest,
                    Principal = installment.Principal,
                    LevelPaymentWithoutSVSD = installment.LevelPaymentWithoutSVSD,
                    LevelPaymentWithSVSD = installment.LevelPaymentWithSVSD,
                    PrincipalBalance = installment.PrincipalBalance
                });
            }
            await _context.SaveChangesAsync();
        }

        public async Task<AmortizationPlanDto> GetAmortizationPlanByClientIdAsync(int clientId)
        {
            var client = await _context.Clients.FindAsync(clientId);
            if (client == null)
            {
                return null; // Manejo de error puede ser mejorado
            }

            var loan = await _context.Loans.FirstOrDefaultAsync(l => l.ClientId == clientId);
            if (loan == null)
            {
                return null; // Manejo de error puede ser mejorado
            }

            var amortizationPlan = await _context.AmortizationPlans
                .Where(ap => ap.LoanId == loan.Id)
                .Select(ap => new AmortizationPlanDto
                {
                    InstallmentNumber = ap.InstallmentNumber,
                    PaymentDate = ap.PaymentDate,
                    Days = ap.Days,
                    Interest = ap.Interest,
                    Principal = ap.Principal,
                    LevelPaymentWithoutSVSD = ap.LevelPaymentWithoutSVSD,
                    LevelPaymentWithSVSD = ap.LevelPaymentWithSVSD,
                    PrincipalBalance = ap.PrincipalBalance
                })
                .ToListAsync();

            return new AmortizationPlanDto
            {
                ClientId = client.Id,
                Name = client.Name,
                IdentityNumber = client.IdentityNumber,
                LoanAmount = loan.LoanAmount,
                AmortizationPlan = amortizationPlan
            };
        }

        private List<AmortizationPlanDto> CalculateAmortizationPlan(Loan loan)
        {
            // Lógica para calcular el plan de amortización basado en los parámetros del préstamo
            // Esto puede incluir fórmulas de interés compuesto, etc.
            // Este es un ejemplo básico que debe ser ajustado para cumplir con los requerimientos específicos

            var amortizationPlan = new List<AmortizationPlanDto>();

            decimal remainingBalance = loan.LoanAmount;
            decimal monthlyInterestRate = loan.InterestRate / 12 / 100;
            int totalPayments = loan.Term;
            DateTime paymentDate = loan.FirstPaymentDate;

            for (int i = 1; i <= totalPayments; i++)
            {
                decimal interest = remainingBalance * monthlyInterestRate;
                decimal principal = (loan.LoanAmount / loan.Term) + interest;
                decimal levelPaymentWithoutSVSD = loan.LoanAmount / loan.Term + interest;
                decimal levelPaymentWithSVSD = levelPaymentWithoutSVSD * 1.02M; // Ejemplo de cálculo con SVSD

                amortizationPlan.Add(new AmortizationPlanDto
                {
                    InstallmentNumber = i,
                    PaymentDate = paymentDate,
                    Days = (paymentDate - loan.DisbursementDate).Days,
                    Interest = interest,
                    Principal = principal,
                    LevelPaymentWithoutSVSD = levelPaymentWithoutSVSD,
                    LevelPaymentWithSVSD = levelPaymentWithSVSD,
                    PrincipalBalance = remainingBalance - principal
                });

                remainingBalance -= principal;
                paymentDate = paymentDate.AddMonths(1);
            }

            return amortizationPlan;
        }
    }
}
