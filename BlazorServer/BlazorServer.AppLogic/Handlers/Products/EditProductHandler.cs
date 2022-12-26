using BlazorServer.AppLogic.Models.Products.EditProduct;
using BlazorServer.DataAccess.Repositories.Interfaces;
using MediatR;

namespace BlazorServer.AppLogic.Handlers.Products
{
    public class EditProductHandler : IRequestHandler<EditProductRequest, EditProductResponse>
    {
        private readonly IProductRepository _productRepository;

        public EditProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<EditProductResponse> Handle(EditProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductAsync(request.ProductId);

            product.Name = request.Name;
            product.Price = request.Price;

            await _productRepository.EditProductAsync(product);

            return new EditProductResponse();
        }
    }
}
