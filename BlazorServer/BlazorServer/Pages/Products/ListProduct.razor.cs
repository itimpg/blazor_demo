using Blazored.Modal;
using Blazored.Modal.Services;
using Blazored.Toast.Services;
using BlazorServer.AppLogic.Models.Products.DeleteProduct;
using BlazorServer.AppLogic.Models.Products.GetProductList;
using BlazorServer.Shared;
using BlazorServer.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.Pages.Products
{
    public partial class ListProduct
    {
        [Inject]
        private IMediator Mediator { get; set; }

        [Inject]
        private IToastService ToastService { get; set; }

        private IEnumerable<ViewProductViewModel> Products = new List<ViewProductViewModel>();

        protected override async Task OnInitializedAsync()
        {
            var result = await Mediator.Send(new GetProductListRequest());
            Products = result.Products.Select(x => new ViewProductViewModel
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                ProductPrice = x.ProductPrice
            });
        }

        public async Task DeleteItem(ViewProductViewModel product)
        {
            bool confirmed = await ShowConfirmationMessage($"Are you sure to Delete {product.ProductName}?");
            if (confirmed)
            {
                await Mediator.Send(new DeleteProductRequest(product.ProductId));
                ToastService.ShowSuccess("The record is deleted", "Success!");
                Products = Products.Where(x => x.ProductId != product.ProductId);
            }
        }


        // Model section

        [CascadingParameter]
        private IModalService Modal { get; set; } = default!;

        private async Task<bool> ShowConfirmationMessage(string message)
        {
            var parameters = new ModalParameters()
                .Add("Message", message);

            var moviesModal = Modal.Show<ConfirmationMessage>("Confirm", parameters);
            var result = await moviesModal.Result;
            return result.Confirmed;
        }
    }
}