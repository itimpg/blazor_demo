using SellerPortal.Core.Interfaces.UiHelpers;
using SellerPortal.UiHelpers;

namespace SellerPortal.Startup
{
    public static partial class StartupExtensions
    {
        public static void AddUtilities(this IServiceCollection services)
        {
            services.AddScoped<IModalHelper, ModalHelper>();
        }
    }
}
