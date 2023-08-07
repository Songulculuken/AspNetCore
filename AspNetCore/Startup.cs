using AspNetCore.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); //Hatayla ilgili kritik bililer verir
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            // Controller => View
            // HomeController => Home
            // Index() => index.cshtml
            app.UseRouting(); // bu kaldýrýlsa url a gitmez. 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "productRoute",
                    pattern: "Songul/{action}",
                    defaults: new { Controller = "Home" }
                    );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{Controller}/{Action}/{id?}", //Id deðeri göndermesen bile ilgili sayfa çalýþmasý için soru iþareti konur.// localhost/Product/Detail/1.{id:int} dersek id integer olmak zorunda vs.
                    defaults:new {Controller="Home",Action="Index"}  
                    );
            });
            //app.UseMiddleware<ResponseEditingMiddleware>();
            //app.UseMiddleware<RequestEditingMiddleware>();
            app.UseAuthorization();

            //ysk.com.tr/
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //}); // bunu kaldýrýrsak ise uygulama çalýþýr ama herhangi bir tepki vermez. 
        }
    }
}
