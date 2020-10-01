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
using PhotoSharingApplication.Web.MVC.Authorization;
using Microsoft.AspNetCore.Authorization;

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
            services.AddRazorPages();

            services.AddDbContext<PhotoSharingApplicationContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("PhotoSharingApplicationContext")));

            services.AddAuthorization(options =>
            {
                options.AddPolicy("PhotoDeletePolicy", policy =>
                    policy.Requirements.Add(new UserOwnsPhotoRequirement()));
            });
            services.AddSingleton<IAuthorizationHandler, UserOwnsPhotoAuthorizationHandler>();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=PhotosEF}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
