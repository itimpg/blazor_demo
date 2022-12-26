using BlazorWasm.Proxy.Models;

namespace BlazorWasm.Proxy.Proxies.Interfaces
{
    public interface IProductProxy
    {
        public Task<List<Product>> GetProductsAsync();

        public Task<Product> GetProductAsync(int productId);

        Task AddProductAsync(Product product);

        Task EditProductAsync(Product product);

        Task DeleteProductAsync(int productId);
    }
}
