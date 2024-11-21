   using webApiVendasOnline.Entities;
   using System.Collections.Generic;
   using System.Threading.Tasks;

   namespace webApiVendasOnline.Services
   {
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(string id);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(string id);
        Task<long> GetProductCountAsync();
        Task<Product> GetProductByNameAsync(string name);
    }
   }
   