using Blazored.LocalStorage;
using Blazored.Modal;

namespace SellerPortal.Startup
{
    public static partial class StartupExtensions
    {
        public static void AddModules(this IServiceCollection services)
        {
            services.AddBlazoredLocalStorageAsSingleton();
            services.AddBlazoredModal();
            services.AddLocalization();
        }
    }
}
