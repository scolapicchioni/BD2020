using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PhotoSharingApplication.Core.Interfaces;
using PhotoSharingApplication.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PhotoSharingApplication.Web.MVC.Data;

namespace PhotoSharingApplication.Web.MVC
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
            //service registration
            services.AddSingleton<IPhotosRepository, PhotosRepository>();
            services.AddControllersWithViews();

            services.AddDbContext<PhotoSharingApplicationContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("PhotoSharingApplicationContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
                    //http://mysite/one/param/and/also/more
                    //http://mysite/something/completely/different/but/still5things
                    //controller = something => new SomethingController()
                    //action = completely => .Completely(some = "different", stuff = "but", blah = "still5things")
                    //some = different
                    //stuff = but
                    //blah = still5things
                    //pattern: "{controller}/{action}/{some}/{stuff}/{blah}");
                    //pattern: "{controller}/{action}");
                    //http://mysite/one/param/and
                    //controller = one
                    //action = param
                    //id = and
                    //http://mysite/one/param
                    //controller = one
                    //action = param
                    //http://mysite/one
                    //controller = one
                    //action = Index
                    //http://mysite
                    //controller = Photos
                    //action = AllPhotos
                    pattern: "{controller=PhotosEF}/{action=Index}/{id?}");
            });
        }
    }
}
