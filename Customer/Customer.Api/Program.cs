using Customer.Application;
using Customer.Application.Contracts;
using Customer.Infrastructure;
using Customer.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add repository
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();

// Add dependency injection of Application and Infrastructure layer
builder.Services
    .AddApplication()
    .AddInfrastructure(
        sqlConnection: builder.Configuration.GetConnectionString("SqlConnection")!, 
        apiAssembly: typeof(Program).GetTypeInfo().Assembly.GetName().Name!);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
