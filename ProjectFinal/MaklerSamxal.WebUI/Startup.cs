using MaklerSamxal.WebUI.Models.DataContexts;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI
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
            services.AddControllersWithViews();

            services.AddDbContext<MaklerSamxalDbContext>(cfg =>
            {
                cfg.UseSqlServer(Configuration.GetConnectionString("cString"));
            });


            services.AddMediatR(this.GetType().Assembly);
            //Mediatr Commanlarda Create olunanda isvalid yazmaq ucun yazilib                
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );
                endpoints.MapControllerRoute(

                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
