using Blazored.Modal;
using Blazored.Toast;
using BlazorWasm;
using BlazorWasm.Proxy.Proxies;
using BlazorWasm.Proxy.Proxies.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IProductProxy, ProductProxy>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddBlazoredToast();
builder.Services.AddBlazoredModal();

await builder.Build().RunAsync();
