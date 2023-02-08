using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using SellerPortal.Core.Interfaces.ViewModels;

namespace SellerPortal.Pages
{
    public abstract class ViewBase<IVM> : ComponentBase
        where IVM : IViewModel
    {
        [Inject]
        protected IStringLocalizer<SellerPortal.Core.Resources.App> Localizer { get; set; } = default!;

        [Inject]
        public IVM ViewModel { get; set; } = default!;

        protected override void OnInitialized()
        {
            if (ViewModel != null)
            {
                ViewModel.OnInit();
            }
        }

        protected override async Task OnInitializedAsync()
        {
            if (ViewModel != null)
            {
                await ViewModel.OnInitAsync();
            }
        }
    }
}
