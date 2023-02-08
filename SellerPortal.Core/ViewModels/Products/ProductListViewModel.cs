using SellerPortal.Core.Interfaces.ViewModels.Products;
using SellerPortal.Core.Models.Products;

namespace SellerPortal.Core.ViewModels.Products
{
    public class ProductListViewModel : BaseViewModel, IProductListViewModel
    {
        public IEnumerable<ProductListItemModel> ProductList { get; set; }
    }
}
