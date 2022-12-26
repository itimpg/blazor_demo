using BlazorServer.AppLogic.Models.Products.GetProduct;
using BlazorServer.DataAccess.Repositories.Interfaces;
using MediatR;

namespace BlazorServer.AppLogic.Handlers.Products
{
    public class GetProductHandler : IRequestHandler<GetProductRequest, GetProductResponse>
    {
        private readonly IProductRepository _productRepository;

        public GetProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetProductResponse> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetProductAsync(request.ProductId);

            return new GetProductResponse
            {
                ProductId = result.ProductId,
                ProductName = result.Name,
                Price = result.Price
            };
        }
    }
}
