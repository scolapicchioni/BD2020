using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationMvcCore.Models;

namespace WebApplicationMvcCore.Data
{
    public class WebApplicationMvcCoreContext : DbContext
    {
        public WebApplicationMvcCoreContext (DbContextOptions<WebApplicationMvcCoreContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplicationMvcCore.Models.Car> Car { get; set; }
    }
}
