using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;
using SellerPortal.Core.Constants;
using System.Globalization;

namespace SellerPortal.Startup
{
    public static partial class StartupExtensions
    {
        public static void AddLocalization(this WebAssemblyHostBuilder builder)
        {
            var jsRuntime = builder.Build().Services.GetRequiredService<IJSRuntime>();
            var js = (IJSInProcessRuntime)jsRuntime;
            var appLanguage = js.Invoke<string>(JavascriptConstants.FUNCTION_GET_APP_CULTURE);
            if (appLanguage != null)
            {
                CultureInfo cultureInfo = new(appLanguage);
                CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
                CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            }
        }
    }
}
