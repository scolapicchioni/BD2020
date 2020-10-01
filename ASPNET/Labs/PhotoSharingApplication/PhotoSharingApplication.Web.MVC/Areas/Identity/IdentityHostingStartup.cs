using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhotoSharingApplication.Web.MVC.Data;

[assembly: HostingStartup(typeof(PhotoSharingApplication.Web.MVC.Areas.Identity.IdentityHostingStartup))]
namespace PhotoSharingApplication.Web.MVC.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<PhotoSharingApplicationWebMVCSecurityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("PhotoSharingApplicationWebMVCSecurityContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<PhotoSharingApplicationWebMVCSecurityContext>();
            });
        }
    }
}