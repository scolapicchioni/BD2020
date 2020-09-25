using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationMvcCore.Models;

namespace WebApplicationMvcCore.Repositories
{
    public interface IProductsRepository
    {
        Task<Product> Create(Product product);
        Task DeleteConfirmed(int id);
        Task<List<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task Update(Product product);
    }
}