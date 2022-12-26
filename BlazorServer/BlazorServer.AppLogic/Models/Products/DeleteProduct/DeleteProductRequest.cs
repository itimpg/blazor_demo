using MediatR;

namespace BlazorServer.AppLogic.Models.Products.DeleteProduct
{
    public class DeleteProductRequest : IRequest<DeleteProductResponse>
    {
        public int ProductId { get; }

        public DeleteProductRequest(int productId)
        {
            ProductId = productId;
        }
    }
}
