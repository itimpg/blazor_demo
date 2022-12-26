using BlazorServer.DataAccess.Entities;
using BlazorServer.DataAccess.Repositories.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BlazorServer.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public readonly ILogger<ProductRepository> _logger;

        public ProductRepository(ILogger<ProductRepository> logger)
        {
            _logger = logger;
        }

        public Task AddProductAsync(Product product)
        {
            _logger.LogInformation($"Add Product: {JsonConvert.SerializeObject(product)}");
            return Task.CompletedTask;
        }

        public Task DeleteProductAsync(int productId)
        {
            _logger.LogInformation($"Delete Product: {productId}");
            return Task.CompletedTask;
        }

        public Task EditProductAsync(Product product)
        {
            _logger.LogInformation($"Edit Product: {JsonConvert.SerializeObject(product)}");
            return Task.CompletedTask;
        }

        public Task<Product> GetProductAsync(int productId)
        {
            return Task.FromResult(new Product { ProductId = 1, Name = "Pokemon Scarlet", Price = 1990 });
        }

        public Task<List<Product>> GetProductsAsync()
        {
            return Task.FromResult(new List<Product>
            {
                new Product { ProductId = 1, Name = "Pokemon Scarlet", Price = 1990 },
                new Product { ProductId = 2, Name = "Pokemon Violet", Price = 1990 },
                new Product { ProductId = 3, Name = "Fire Emblem Engage", Price = 1890 }
            });
        }
    }
}
