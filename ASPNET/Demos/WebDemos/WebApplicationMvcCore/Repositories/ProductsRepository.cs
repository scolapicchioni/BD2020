using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationMvcCore.Data;
using WebApplicationMvcCore.Models;

namespace WebApplicationMvcCore.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ProductsDbContext _context;

        public ProductsRepository(ProductsDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Product.ToListAsync();
        }

        // GET: Products/Details/5
        public async Task<Product> GetProductById(int id)
        {
            return await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Product> Create(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task Update(Product product)
        {
            _context.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
