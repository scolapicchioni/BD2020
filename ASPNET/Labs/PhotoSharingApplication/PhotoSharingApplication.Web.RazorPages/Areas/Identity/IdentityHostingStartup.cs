using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhotoSharingApplication.Web.RazorPages.Data;

[assembly: HostingStartup(typeof(PhotoSharingApplication.Web.RazorPages.Areas.Identity.IdentityHostingStartup))]
namespace PhotoSharingApplication.Web.RazorPages.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<PhotoSharingApplicationRazorPagesSecurityContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("PhotoSharingApplicationRazorPagesSecurityContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<PhotoSharingApplicationRazorPagesSecurityContext>();
            });
        }
    }
}