using Microsoft.Extensions.DependencyInjection;
using TEST_SOFTWARE.CORE.Interfaces.Respositories;
using TEST_SOFTWARE.CORE.Interfaces.Services;
using TEST_SOFTWARE.CORE.Services;
using TEST_SOFTWARE.INFRASTRUCTURE.Repositories;

namespace TEST_SOFTWARE.INFRASTRUCTURE.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IDirectorio), typeof(PersonaRepository));
            services.AddScoped(typeof(IVentas), typeof(FacturaRepository));

            services.AddTransient<IDirectorioService, DirectorioService>();
            services.AddTransient<IVentasService, VentasService>();

            return services;
        }
    }
}
