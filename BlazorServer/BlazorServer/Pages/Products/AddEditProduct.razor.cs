using Blazored.Toast.Services;
using BlazorServer.AppLogic.Models.Products.AddProduct;
using BlazorServer.AppLogic.Models.Products.EditProduct;
using BlazorServer.AppLogic.Models.Products.GetProduct;
using BlazorServer.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace BlazorServer.Pages.Products
{
    public partial class AddEditProduct
    {
        [Inject]
        public IMediator Mediator { get; set; } = default!;

        [Inject]
        public IToastService ToastService { get; set; } = default!;

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        private AddEditProductViewModel Product { get; } = new AddEditProductViewModel();

        public bool IsEditMode
        {
            get
            {
                return ProductId != 0;
            }
        }

        private string Title
        {
            get
            {
                return IsEditMode ? "Edit" : "Add";
            }
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
                var result = await Mediator.Send(new GetProductRequest(ProductId));
                Product.ProductName = result.ProductName;
                Product.ProductPrice = result.Price;
            }
        }

        private async Task SaveData()
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
            await Mediator.Send(new AddProductRequest(Product.ProductName, Product.ProductPrice));
            ToastService.ShowSuccess("Product is added successfully.", "Success!");
        }

        private async Task EditData()
        {
            await Mediator.Send(new EditProductRequest(ProductId, Product.ProductName, Product.ProductPrice));
            ToastService.ShowSuccess("Prdouct is edited successfully.", "Success!");
        }
    }
}