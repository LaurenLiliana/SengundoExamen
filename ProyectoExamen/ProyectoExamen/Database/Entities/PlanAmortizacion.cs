namespace ProyectoExamen.Database.Entities
{
    public class PlanAmortizacion
    {
        public int Id { get; set; }
        public int PrestamoId { get; set; }
        public int NumeroCuota { get; set; }
        public DateTime FechaPago { get; set; }
        public int Dias { get; set; }
        public decimal Interes { get; set; }
        public decimal Principal { get; set; }
        public decimal SaldoPrincipal { get; set; }
    }
}
