namespace StaffSystem.Application;
using StaffSystem.Application.Services.Employee;
using Microsoft.Extensions.DependencyInjection;
using StaffSystem.Domain.Entities;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(IServiceCollection services)
    {
        services.AddScoped<IEmployeeService, EmployeeService>();

        return services;
    }
}
