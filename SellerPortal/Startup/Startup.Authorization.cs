using Microsoft.AspNetCore.Components.Authorization;
using SellerPortal.Core.Auth;

namespace SellerPortal.Startup
{
    public static partial class StartupExtensions
    {
        public static void AddCustomAuthorizations(this IServiceCollection services)
        {
            services.AddOptions();
            services.AddAuthorizationCore();
            services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
        }
    }
}
