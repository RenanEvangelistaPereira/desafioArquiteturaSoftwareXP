   using webApiVendasOnline.Entities;
   using MongoDB.Driver;
   using System.Collections.Generic;
   using System.Threading.Tasks;

   namespace webApiVendasOnline.Repositories
   {
       public class ProductRepository : IProductRepository
       {
           private readonly IMongoCollection<Product> _products;

           public ProductRepository(YourMongoDbSettings settings)
           {
               var client = new MongoClient(settings.ConnectionString);
               var database = client.GetDatabase(settings.DatabaseName);
               _products = database.GetCollection<Product>("Products");
           }

           public async Task<IEnumerable<Product>> GetAllProductsAsync()
           {
               return await _products.Find(product => true).ToListAsync();
           }

           public async Task<Product> GetProductByIdAsync(string id)
           {
               return await _products.Find<Product>(product => product.Id == id).FirstOrDefaultAsync();
           }

           public async Task CreateProductAsync(Product product)
           {
               await _products.InsertOneAsync(product);
           }

           public async Task UpdateProductAsync(Product product)
           {
               await _products.ReplaceOneAsync(p => p.Id == product.Id, product);
           }

           public async Task DeleteProductAsync(string id)
           {
               await _products.DeleteOneAsync(product => product.Id == id);
           }
       }
   }
   