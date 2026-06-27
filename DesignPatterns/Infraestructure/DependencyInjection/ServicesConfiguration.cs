using DesignPatterns.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DesignPatterns.Infraestructure.DependencyInjection
{
    /// <summary>
    /// Service registration module that centralizes dependency configuration within
    /// the IoC container. Respects the Open/Closed Principle (OCP) by isolating
    /// registration logic so that new services can be added without modifying
    /// the Startup class.
    /// </summary>
    public class ServicesConfiguration
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Option for database-backed persistence (currently disabled)
            //services.AddTransient<IVehicleRepository, DBVehicleRepository>();
            
            // Singleton + Repository pattern: registers a single shared instance of
            // MyVehiclesRepository, ensuring that the in-memory vehicle collection
            // persists across all HTTP requests throughout the application lifetime.
            services.AddSingleton<IVehicleRepository, MyVehiclesRepository>();
        }
    }
}
