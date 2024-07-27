﻿namespace ProyectoExamen.Database.Entities
{
    public class Prestamo
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public decimal Monto { get; set; }
        public decimal TasaInteres { get; set; }
        public int Plazo { get; set; }
        public Cliente Cliente { get; set; }    
        public DateTime FechaDesembolso { get; set; }
        public DateTime FechaPrimerPago { get; set; }
    }

}

