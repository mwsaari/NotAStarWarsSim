using BlazorPanzoom;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NotAStarWarsSim.Client;
using NotAStarWarsSim.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IPlayerService, PlayerService>();
builder.Services.AddScoped<IPlanetService, PlanetService>();
builder.Services.AddBlazorPanzoomServices();

await builder.Build().RunAsync();
