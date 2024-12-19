using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using SkjødeSystem;
using SkjødeSystem.Services;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Load configuration from appsettings.json
var configuration = builder.Configuration;

// Configure HttpClient with API base URL
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(configuration["ApiBaseUrl"]) // Reads the base URL from appsettings.json
});

// Add services
builder.Services.AddMudServices();
builder.Services.AddScoped<IApartmentService, ApartmentService>();
builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<ILoginService, LoginService>();

await builder.Build().RunAsync();
