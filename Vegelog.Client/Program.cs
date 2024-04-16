using Fukicycle.Tool.AppBase;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Vegelog.Client;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("Default", sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["ServiceURI"] + "api/v1/") });
builder.Services.AddAppBase();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
