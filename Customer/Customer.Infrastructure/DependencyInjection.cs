using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Customer.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string sqlConnection,
        string apiAssembly)
    {
        services.AddDbContext<CustomerDBContext>(options =>
            options.UseSqlServer(sqlConnection, 
                sqlOptions =>
                {
                    sqlOptions.MigrationsAssembly(apiAssembly);
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null
                    );
                })
        );

        return services;
    }
}
