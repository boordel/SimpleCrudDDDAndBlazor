using Mc2.CrudTest.Presentation.Client;
using Mc2.CrudTest.Presentation.Client.Services;
using Mc2.CrudTest.Presentation.Client.Services.Contracts;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Add data services
builder.Services.AddScoped<ICustomerService, CustomerService>();

await builder.Build().RunAsync();
