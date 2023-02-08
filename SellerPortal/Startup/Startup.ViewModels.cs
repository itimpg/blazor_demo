using SellerPortal.Core.Interfaces.ViewModels.Authorizations;
using SellerPortal.Core.ViewModels.Authorizations;

namespace SellerPortal.Startup
{
    public static partial class StartupExtensions
    {
        public static void AddViewModels(this IServiceCollection services)
        {
            services.AddTransient<ILoginViewModel, LoginViewModel>();
        }
    }
}
