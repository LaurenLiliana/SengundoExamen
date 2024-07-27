using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProyectoExamen.Services.Interfaces;
using ProyectoExamen.Services.Implementaciones;
using ProyectoExamen.Services;
using ProyectoExamen.Entities;

namespace ProyectoExamen
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Configurar la conexión a la base de datos
            services.AddDbContext<ApiDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Inyección de dependencias
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IPrestamoService, PrestamoService>();
            services.AddScoped<IPlanAmortizacionService, PlanAmortizacionService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}