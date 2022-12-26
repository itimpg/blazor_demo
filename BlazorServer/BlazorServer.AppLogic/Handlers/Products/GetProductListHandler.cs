using BlazorServer.AppLogic.Models;
using BlazorServer.AppLogic.Models.Products.GetProductList;
using BlazorServer.DataAccess.Repositories.Interfaces;
using MediatR;

namespace BlazorServer.AppLogic.Handlers.Products
{
    public class GetProductListHandler : IRequestHandler<GetProductListRequest, GetProductListResponse>
    {
        private readonly IProductRepository _productRepository;

        public GetProductListHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<GetProductListResponse> Handle(GetProductListRequest request, CancellationToken cancellationToken)
        {
            return new GetProductListResponse
            {
                Products = (await _productRepository.GetProductsAsync()).Select(x => new ProductModel
                {
                    ProductId = x.ProductId,
                    ProductName = x.Name,
                    ProductPrice = x.Price
                })
            };
        }
    }
}