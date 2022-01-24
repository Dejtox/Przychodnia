using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Przychodnia.Client;
using Syncfusion.Blazor;
using Radzen;
using Przychodnia.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<IVisitService, VisitService>(client =>
{
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});
builder.Services.AddHttpClient<IUserService, UserService>(client1 =>
{
    client1.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress);
});
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddSingleton<AppDataService>();
builder.Services.AddScoped<VisitService>();
builder.Services.AddScoped<UserService>();
await builder.Build().RunAsync();
