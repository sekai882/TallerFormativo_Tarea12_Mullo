using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesignPatterns.Infraestructure.DependencyInjection;

namespace DesignPatterns
{
    /// <summary>
    /// Application startup class that orchestrates service initialization and the HTTP
    /// request pipeline. Delegates dependency registration to <see cref="ServicesConfiguration"/>
    /// to uphold the Single Responsibility Principle (SRP) — each component manages
    /// exactly one concern.
    /// </summary>
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// Registers required services in the dependency injection container.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {

            var diModule = new ServicesConfiguration();
            services.AddControllersWithViews();
            diModule.ConfigureServices(services);
        }

        /// <summary>
        /// Configures the middleware pipeline that processes each incoming HTTP request.
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. Adjust for production environments as needed.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
