namespace ProyectoExamen.Dtos
{
    public class PrestamoDto
    {
        public decimal Monto { get; set; }
        public decimal TasaInteres { get; set; }
        public int Plazo { get; set; }
        public DateTime FechaDesembolso { get; set; }
        public DateTime FechaPrimerPago { get; set; }
        public ClienteDto Cliente { get; set; }

    }
}
