using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using u3_aspnetcore_efcore_18100220.Models;

namespace u3_aspnetcore_efcore_18100220 {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }
        /*public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<NombreDeTuContexto>(opts => {
                opts.UseSqlServer(
                Configuration["ConnectionStrings:Conexion"]);
            });
        }*/
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddControllersWithViews();
            services.AddDbContext<TiendaDeInstrumentosContext>(opts => {
                opts.UseSqlServer(
                Configuration["ConnectionStrings:Conexion"]);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=InstrumentoMusical}/{action=ListadoRegistros}/{id?}");
            });
        }
    }
}
