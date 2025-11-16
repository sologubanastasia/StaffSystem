namespace StaffSystem.Infrastructure;

using System.Collections.Generic;
using StaffSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StaffSystem.Infrastructure.Repositories;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using StaffSystem.Domain.Entities;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
                               ?? throw new InvalidOperationException("ConnectionString not found");
        
        services.AddDbContext<StaffSystemDbContext>(options =>
        {
            options.UseNpgsql(connectionString,
                npgsqlOptions =>
                {
                    npgsqlOptions.MigrationsAssembly(typeof(DependencyInjection).Assembly.FullName);
                });
        });

        services.AddSingleton(new DatabaseConnectionFactory(connectionString));

        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        return services;                        
    }
}
