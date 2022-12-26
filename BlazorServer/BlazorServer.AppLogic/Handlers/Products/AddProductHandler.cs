using BlazorServer.AppLogic.Models.Products.AddProduct;
using BlazorServer.DataAccess.Entities;
using BlazorServer.DataAccess.Repositories.Interfaces;
using MediatR;

namespace BlazorServer.AppLogic.Handlers.Products
{
    public class AddProductHandler : IRequestHandler<AddProductRequest, AddProductResponse>
    {
        private readonly IProductRepository _productRepository;

        public AddProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<AddProductResponse> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            await _productRepository.AddProductAsync(new Product
            {
                Name = request.Name,
                Price = request.Price
            });

            return new AddProductResponse();
        }
    }
}
