using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SellerPortal;
using SellerPortal.Startup;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddModules();
builder.Services.AddServices();
builder.Services.AddViewModels();
builder.Services.AddCustomAuthorizations();
builder.Services.AddUtilities();
builder.Services.AddLogs();

builder.AddLocalization();

await builder.Build().RunAsync();
