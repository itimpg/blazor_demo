using SellerPortal.Core.Interfaces.Services;
using SellerPortal.Core.Services;

namespace SellerPortal.Startup
{
    public static partial class StartupExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
