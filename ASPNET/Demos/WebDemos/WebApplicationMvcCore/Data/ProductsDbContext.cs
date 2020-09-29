using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationMvcCore.Models;

namespace WebApplicationMvcCore.Data
{
    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext (DbContextOptions<ProductsDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplicationMvcCore.Models.Product> Product { get; set; }

        public DbSet<WebApplicationMvcCore.Models.Customer> Customer { get; set; }
    }
}
