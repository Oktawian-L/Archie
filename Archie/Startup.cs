using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Archie.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Archie
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Console.WriteLine("Odczytuje konfigiuracje");
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Server=(localdb)\mssqllocaldb;Database=archie;Trusted_Connection=True;ConnectRetryCount=0";
            Console.WriteLine("Stawiam uslugi");
            services.AddSingleton(_ => Configuration);
            services.AddSingleton<SyrakuzaContext>(_ => new SyrakuzaContext(Configuration.GetConnectionString(connection)));
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            Console.WriteLine("Syncgronizacja");
            SyrakuzaContextSeed.SeedAsync(app)
              .Wait();
           app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");



            });
        }
    }
}
