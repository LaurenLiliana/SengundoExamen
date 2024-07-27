//namespace ProyectoExamen.Dtos
//{
//    public class GestionPrestamoDto
//    {
//        public string Nombre { get; set; }
//        public string NumeroId { get; set; }
//        public decimal LoanAmount { get; set; } //LoadAmount
//        public decimal CommissionRate { get; set; }
//        public decimal InterestRate { get; set; }
//        public int Term { get; set; }
//        public DateTime DisbursementDate { get; set; }
//        public DateTime FirstPaymentDate { get; set; }
//    }
//}

namespace ProyectoExamen.Dtos
{
    public class SolicitudPrestamoDto
    {
        public string Nombre { get; set; }
        public string NumeroId { get; set; }
        public decimal MontoPrestamo { get; set; }
        public decimal TasaComision { get; set; }
        public decimal TasaInteres { get; set; }
        public int Plazo { get; set; }
        public DateTime FechaPago { get; set; }
        public DateTime PrimerPago { get; set; }
    }
}
