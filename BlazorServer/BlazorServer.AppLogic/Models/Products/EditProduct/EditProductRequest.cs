using MediatR;

namespace BlazorServer.AppLogic.Models.Products.EditProduct
{
    public class EditProductRequest :IRequest<EditProductResponse>
    { 
        public int ProductId { get; }
        public string Name { get; }
        public decimal Price { get; }
         
        public EditProductRequest  (int productId, string name , decimal price)
        {
            ProductId = productId;
            Name = name;
            Price = price;
        }
    }
}
