using MediatR;

namespace BlazorServer.AppLogic.Models.Products.AddProduct
{
    public class AddProductRequest : IRequest<AddProductResponse>
    {
        public string Name { get; }
        public decimal Price { get; }

        public AddProductRequest(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
    }
}
