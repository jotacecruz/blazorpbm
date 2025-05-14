using BlazorPBM;
using BlazorPBM.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

#region Radzen
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
#endregion Radzen

builder.Services.AddSingleton<ReferenceDataService>();
builder.Services.AddScoped(typeof(DatabaseService<>));
builder.Services.AddScoped<ErrorService>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<InsuredService>();
builder.Services.AddScoped<LifeCaseService>();
builder.Services.AddScoped<LifeCaseOfferService>();
builder.Services.AddScoped<LifeCaseRemarkService>();

await builder.Build().RunAsync();
