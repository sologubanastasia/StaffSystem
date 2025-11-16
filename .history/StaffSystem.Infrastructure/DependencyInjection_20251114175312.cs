namespace StaffSystem.Infrastructure;
using StaffSystem.Collection.Generic;
using  StaffSystem.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StaffSystem.Infrastructure.Repositories;
using Npgsql;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
                               ?? throw new InvalidOperationException("ConnectionString not found");

        services.AddSingleton(new DatabaseConnectionFactory(connectionString));

        services.AddScoped<IEmployeeRepository, EmloyeeRepository>();
        return services;                        
    }
}
