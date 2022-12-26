using Blazored.Modal;
using Blazored.Modal.Services;
using Blazored.Toast.Services;
using BlazorWasm.Proxy.Proxies.Interfaces;
using BlazorWasm.Shared;
using BlazorWasm.ViewModels;
using Microsoft.AspNetCore.Components;

namespace BlazorWasm.Pages.Products
{
    public partial class ListProduct
    { 
        [Inject]
        private IProductProxy Proxy { get; set; } = default!;

        [Inject]
        private IToastService ToastService { get; set; } = default!;

        private IEnumerable<ViewProductViewModel> Products = new List<ViewProductViewModel>();

        protected override async Task OnInitializedAsync()
        {
            var result = await Proxy.GetProductsAsync();
            Products = result.Select(x => new ViewProductViewModel { ProductId = x.ProductId, ProductName = x.ProductName, ProductPrice = x.ProductPrice });
        }

        public async Task DeleteItem(ViewProductViewModel product)
        {
            bool confirmed = await ShowConfirmationMessage($"Are you sure to Delete {product.ProductName}?");
            if (confirmed)
            {
                await Proxy.DeleteProductAsync(product.ProductId);
                ToastService.ShowSuccess("The record is deleted", "Success!");
                this.Products = this.Products.Where(x => x.ProductId != product.ProductId);
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