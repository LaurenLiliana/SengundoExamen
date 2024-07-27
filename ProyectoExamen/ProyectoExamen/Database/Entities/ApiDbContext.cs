

//using Microsoft.EntityFrameworkCore;
//using ProyectoExamen.Database.Entities;

//namespace ProyectoExamen.Database.Entities
//{
//    public class ApiDbContext : DbContext
//    { 
//        public DbSet<Cliente> Clientes { get; set; }
//        public DbSet<Prestamo> Prestamos { get; set; }
//        public DbSet<PlanPago> PlanPagos { get; set; } //AmortizacionPlan

//    }
//}

using Microsoft.EntityFrameworkCore;
using ProyectoExamen.Database.Entities;

namespace ProyectoExamen.Entities
{
    public class ApiDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<PlanAmortizacion> PlanesAmortizacion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("\"Server=PC;Database=Proyecto;User Id=userName;Password=mySuperContraseña; Trusted_Connection = false; TrustedServerCertificate= true;\"");
        }
    }
}
