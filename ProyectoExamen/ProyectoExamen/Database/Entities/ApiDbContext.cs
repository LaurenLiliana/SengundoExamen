

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

namespace ProyectoExamen.Entities
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<PlanPrestamo> PlanPrestamos { get; set; }
    }
}
