using BlazorServer.DataAccess.Entities;

namespace BlazorServer.DataAccess.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetProductsAsync();

        public Task<Product> GetProductAsync(int productId);

        Task AddProductAsync(Product product);

        Task EditProductAsync(Product product);

        Task DeleteProductAsync(int productId);
    }
}
