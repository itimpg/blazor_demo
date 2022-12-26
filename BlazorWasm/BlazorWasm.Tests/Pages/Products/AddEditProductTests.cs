using Blazored.Toast.Services;
using BlazorWasm.Pages.Products;
using BlazorWasm.Proxy.Models;
using BlazorWasm.Proxy.Proxies.Interfaces;
using Moq;

namespace BlazorWasm.Tests.Pages.Products
{
    public class AddEditProductTests
    {
        private readonly AddEditProduct _instance = new AddEditProduct();

        private Mock<IProductProxy> _proxy;
        private Mock<IToastService> _toastService;
        private Mock<FakeNavigationManager> _navigationManager;

        [SetUp]
        public void Setup()
        {
            _proxy = new Mock<IProductProxy>();
            _proxy.Setup(x => x.GetProductAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(new Product { ProductId = 112, ProductName = "PRODUCT_NAME", ProductPrice = 99 }));

            _toastService = new Mock<IToastService>();

            _navigationManager = new Mock<FakeNavigationManager>();

            _instance.Proxy = _proxy.Object;
            _instance.ToastService = _toastService.Object;
            _instance.NavigationManager = _navigationManager.Object;
        }

        [Test]
        [TestCase(0, "Add")]
        [TestCase(1, "Edit")]
        public void Title_Should_ReturnTextCorrectly_When_ProductIdIsSet(int productId, string expectedTitle)
        {
            _instance.ProductId = productId;

            Assert.That(_instance.Title, Is.EqualTo(expectedTitle));
        }

        [Test]
        public async Task InitialAddEditProductModel_Should_NotLoadProductData_When_InitializeWithAddMode()
        {
            _instance.ProductId = 0;

            await _instance.InitialAddEditProductModel();

            _proxy.Verify(x => x.GetProductAsync(It.IsAny<int>()), Times.Never());

            Assert.NotNull(_instance.Product);
        }

        [Test]
        public async Task InitialAddEditProductModel_Should_LoadProductData_When_InitializeWithEditMode()
        {
            _instance.ProductId = 1;

            await _instance.InitialAddEditProductModel();

            _proxy.Verify(x => x.GetProductAsync(It.IsAny<int>()), Times.Once());

            Assert.NotNull(_instance.Product);
            Assert.That(_instance.Product.ProductName, Is.EqualTo("PRODUCT_NAME"));
            Assert.That(_instance.Product.ProductPrice, Is.EqualTo(99));
        }

        [Test]
        public async Task SaveData_Should_AddNewData_When_SaveInAddMode()
        {
            _instance.ProductId = 0;

            await _instance.SaveData();

            _proxy.Verify(x => x.AddProductAsync(It.IsAny<Product>()), Times.Once());
        }

        [Test]
        public async Task SaveData_Should_EditData_When_SaveInEditMode()
        {
            _instance.ProductId = 1;

            await _instance.SaveData();

            _proxy.Verify(x => x.EditProductAsync(It.IsAny<Product>()), Times.Once());
        }
    }
}
