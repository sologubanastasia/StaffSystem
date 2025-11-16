namespace StaffSystem.Infrastructure;
using  StaffSystem.Infrastructure.Data;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this ServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
                               ?? throw new InvalidOperationException("ConnectionString not found");

        services.AddSingleton(new DatabaseConnectionFactory(connectionString));

        services.AddScoped<IEmployeeRepository, EmloyeeRepository>();
        return services;                        
    }
}
