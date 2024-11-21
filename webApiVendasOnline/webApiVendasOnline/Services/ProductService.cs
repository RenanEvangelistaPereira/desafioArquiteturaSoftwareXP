   using webApiVendasOnline.Entities;
   using webApiVendasOnline.Repositories;
   using System.Collections.Generic;
   using System.Threading.Tasks;

   namespace webApiVendasOnline.Services
   {
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<Product> GetProductByIdAsync(string id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task CreateProductAsync(Product product)
        {
            ValidateProduct(product);
            await _productRepository.CreateProductAsync(product);
        }

        public async Task UpdateProductAsync(Product product)
        {
            ValidateProduct(product);
            await _productRepository.UpdateProductAsync(product);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productRepository.DeleteProductAsync(id);
        }

        public async Task<long> GetProductCountAsync() 
        {
            return await _productRepository.GetProductCountAsync();
        }

        public async Task<Product> GetProductByNameAsync(string name) 
        {
            return await _productRepository.GetProductByNameAsync(name);
        }

        private void ValidateProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
            {
                throw new ArgumentException("Product name cannot be empty.");
            }

            if (product.Price <= 0)
            {
                throw new ArgumentException("Product price must be greater than zero.");
            }

            if (string.IsNullOrWhiteSpace(product.BarCode) || product.BarCode.Length > 20)
            {
                throw new ArgumentException("Product bar code must be provided and cannot exceed 20 characters.");
            }

            if (product.StartSellDate == default)
            {
                throw new ArgumentException("Product start sell date must be a valid date.");
            }

            if (string.IsNullOrWhiteSpace(product.Category))
            {
                throw new ArgumentException("Product category cannot be empty.");
            }

            if (product.StockQuantity < 0)
            {
                throw new ArgumentException("Product stock quantity cannot be negative.");
            }

            if (string.IsNullOrWhiteSpace(product.Manufacturer))
            {
                throw new ArgumentException("Product manufacturer cannot be empty.");
            }
        }
    }
   }
   