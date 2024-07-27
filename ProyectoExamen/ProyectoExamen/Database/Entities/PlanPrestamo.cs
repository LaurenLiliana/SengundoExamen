namespace ProyectoExamen.Database.Entities
{
        public class Plan /*AmortizationPlan*/
        {
            public int Id { get; set; }
            public int PrestamoId { get; set; } //LoanId
            public decimal Prestamo { get; set; } //Prestamo
            public int Cuota { get; set; } //InstallmentNumber
            public DateTime DiaPago { get; set; } //PaymentDate 
            public int Dias { get; set; }
            public decimal Interes { get; set; } //Interest
            public decimal Principal { get; set; }
            //public decimal LevelPaymentWithoutSVSD { get; set; }
            //public decimal LevelPaymentWithSVSD { get; set; }
            public decimal BalancePrincipal { get; set; }
        }
    }

