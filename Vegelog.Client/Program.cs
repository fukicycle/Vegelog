using Fukicycle.Tool.AppBase;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Vegelog.Client;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Vegelog.Client.Securities;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("Default", sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["ServiceURI"] + "api/v1/") });
builder.Services.AddAppBase();
builder.Services.AddScoped<AppSettings>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(service => service.GetRequiredService<CustomAuthenticationStateProvider>());
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Default"));

await builder.Build().RunAsync();
