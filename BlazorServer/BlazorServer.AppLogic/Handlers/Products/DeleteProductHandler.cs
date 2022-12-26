using BlazorServer.AppLogic.Models.Products.DeleteProduct;
using BlazorServer.DataAccess.Repositories.Interfaces;
using MediatR;

namespace BlazorServer.AppLogic.Handlers.Products
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            await _productRepository.DeleteProductAsync(request.ProductId);

            return new DeleteProductResponse();
        }
    }
}
