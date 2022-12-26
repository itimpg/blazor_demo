using BlazorWasm.Proxy.Models;
using BlazorWasm.Proxy.Proxies.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace BlazorWasm.Proxy.Proxies
{
    public class ProductProxy : IProductProxy
    { 
        private readonly ILogger<ProductProxy> _logger;

        public ProductProxy(ILogger<ProductProxy> logger)
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
            return Task.FromResult(new Product { ProductId = 1, ProductName = "Pokemon Scarlet", ProductPrice = 1990 });
        }

        public Task<List<Product>> GetProductsAsync()
        {
            return Task.FromResult(new List<Product>
            {
                new Product { ProductId = 1, ProductName = "Pokemon Scarlet", ProductPrice = 1990 },
                new Product { ProductId = 2, ProductName = "Pokemon Violet", ProductPrice = 1990 },
                new Product { ProductId = 3, ProductName = "Fire Emblem Engage", ProductPrice = 1890 }
            });
        }
    }
}
