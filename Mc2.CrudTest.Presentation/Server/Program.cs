using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Add Customer domain service client
if (builder.WebHost.GetSetting("environment") == "Development")
{
    builder.Services.AddHttpClient("CustomerService", httpClient =>
    {
        httpClient.BaseAddress = new Uri(builder.Configuration.GetSection("Services")["CustomerUrl"]!);
    }).ConfigurePrimaryHttpMessageHandler(() =>
    {
        return new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; }
        };
    });
}
else
{
    builder.Services.AddHttpClient("CustomerService", httpClient =>
    {
        httpClient.BaseAddress = new Uri(builder.Configuration.GetSection("Services")["CustomerUrl"]!);
    });
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
