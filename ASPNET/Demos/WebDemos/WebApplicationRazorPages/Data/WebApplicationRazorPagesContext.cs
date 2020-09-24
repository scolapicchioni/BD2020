using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationRazorPages.Models;

namespace WebApplicationRazorPages.Data
{
    public class WebApplicationRazorPagesContext : DbContext
    {
        public WebApplicationRazorPagesContext (DbContextOptions<WebApplicationRazorPagesContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplicationRazorPages.Models.Car> Car { get; set; }
    }
}
