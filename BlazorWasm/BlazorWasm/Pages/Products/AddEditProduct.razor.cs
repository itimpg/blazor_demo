using Blazored.Toast.Services;
using BlazorWasm.Proxy.Models;
using BlazorWasm.Proxy.Proxies.Interfaces;
using BlazorWasm.ViewModels;
using Microsoft.AspNetCore.Components;

namespace BlazorWasm.Pages.Products
{
    public partial class AddEditProduct
    {
        [Inject]
        public IProductProxy Proxy { get; set; } = default!;

        [Inject]
        public IToastService ToastService { get; set; } = default!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        public AddEditProductViewModel Product { get; } = new AddEditProductViewModel();

        private bool IsEditMode
        {
            get { return ProductId != 0; }
        }

        public string Title
        {
            get { return IsEditMode ? "Edit" : "Add"; }
        }

        [Parameter]
        public int ProductId { get; set; }

        protected override Task OnInitializedAsync()
        {
            return InitialAddEditProductModel();
        }

        public async Task InitialAddEditProductModel()
        {
            if (IsEditMode)
            {
                var result = await Proxy.GetProductAsync(ProductId);
                Product.ProductName = result.ProductName;
                Product.ProductPrice = result.ProductPrice;
            }
        }

        public async Task SaveData()
        {
            if (IsEditMode)
            {
                await EditData();
            }
            else
            {
                await AddData();
            }
            NavigationManager.NavigateTo("products");
        }

        private async Task AddData()
        {
            await Proxy.AddProductAsync(new Product
            {
                ProductName = Product.ProductName,
                ProductPrice = Product.ProductPrice
            });
            ToastService.ShowSuccess("Product is added successfully.", "Success!");
        }

        private async Task EditData()
        {
            await Proxy.EditProductAsync(new Product
            {
                ProductId = Product.ProductId,
                ProductName = Product.ProductName,
                ProductPrice = Product.ProductPrice
            });
            ToastService.ShowSuccess("Prdouct is edited successfully.", "Success!");
        }
    }
}