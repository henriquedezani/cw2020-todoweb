using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TodoWeb
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // adicionar as middlewares:
            // MVC, Identity, DataContext, AddSingleton
            // services.AddMvc(); // versão 2.0-
            services.AddControllersWithViews(); // vesão 3.0+

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Todo}/{action=Index}/{id?}");
            });
        }
    }
}
