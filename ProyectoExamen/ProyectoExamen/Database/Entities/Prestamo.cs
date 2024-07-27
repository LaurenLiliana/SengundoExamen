//namespace ProyectoExamen.Database.Entities
//{
//    public class Prestamo
//    {
//        public int Id { get; set; }
//        public int ClientId { get; set; }
//        public Cliente Clientes { get; set; }
//        public decimal MontoPrestamo { get; set; } //loadmount
//        public decimal Tasa { get; set; } //tasa
//        public decimal Intereses { get; set; } //Interest rate
//        public int Termino { get; set; } //Term
//        public DateTime FechaPago { get; set; } //DisbursementDate
//        public DateTime DiaPago { get; set; } //FirstPaymentDate
//    }
//}

namespace ProyectoExamen.Database.Entities
{
    public class Prestamo
    {
        public int Id { get; set; }
        public int ClienteId { get; set; } //ClienteId
        public Cliente Clientes { get; set; }
        public decimal MontoPrestamo { get; set; } //LoanAmount 
        public decimal TasaComision { get; set; } //CommissionRate
        public decimal TasaInteres { get; set; } //InterestRate
        public int Plazo { get; set; } //Term
        public DateTime FechaPago { get; set; } //DisbursementDate
        public DateTime PrimerPago { get; set; } //FirstPaymentDate
    }
}
