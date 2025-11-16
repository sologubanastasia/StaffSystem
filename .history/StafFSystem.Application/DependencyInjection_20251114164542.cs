namespace StaffSystem.Application;
using StaffSystem.Application.Services.Employee;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(IServiceCollection services)
    {
        services.AddScoped<IEmpoyeeService, EmpoyeeService>();

        return services;
    }
}
