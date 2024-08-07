﻿//namespace ProyectoExamen.Dtos
//{
//    public class AmortizationPlan
//    {
//        public int InstallmentNumber { get; set; }
//        public DateTime PaymentDate { get; set; }
//        public int Days { get; set; }
//        public decimal Interest { get; set; }
//        public decimal Principal { get; set; }
//        public decimal LevelPaymentWithoutSVSD { get; set; }
//        public decimal LevelPaymentWithSVSD { get; set; }
//        public decimal PrincipalBalance { get; set; }
//    }
//}

namespace ProyectoExamen.Dtos
{
    public class PlanDto
    {
        public int Cuota { get; set; }
        public DateTime Pago { get; set; } //PaymentDate
        public int Dias { get; set; }
        public decimal Interes { get; set; }
        public decimal Principal { get; set; }
        //public decimal LevelPaymentWithoutSVSD { get; set; }
        //public decimal LevelPaymentWithSVSD { get; set; }
        public decimal PrincipalBalance { get; set; }
    }
}
