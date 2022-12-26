using MediatR;

namespace BlazorServer.AppLogic.Models.Products.GetProduct
{
    public class GetProductRequest : IRequest<GetProductResponse>
    {
        public int ProductId { get; }

        public GetProductRequest(int productId)
        {
            this.ProductId = productId;
        }
    }
}
