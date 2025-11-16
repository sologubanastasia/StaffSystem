using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StaffSystem.Application.Interfaces;
using StaffSystem.Infrastructure.Data;
using StaffSystem.Infrastructure.Repositories;

namespace StaffSystem.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // 1. КОНФІГУРАЦІЯ DBContext
            // Використовуємо .IsConfigured, щоб уникнути подвійної реєстрації
            services.AddDbContext<StaffSystemDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                if (string.IsNullOrEmpty(connectionString))
                {
                    // Це може викликати збій, якщо рядок підключення не знайдено
                    throw new InvalidOperationException("DefaultConnection string not found in configuration.");
                }
                
                // Встановлення PostgreSQL з Npgsql
                options.UseNpgsql(connectionString);
            });

            // 2. РЕЄСТРАЦІЯ РЕПОЗИТОРІЇВ
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            // Додайте інші репозиторії тут...

            return services;
        }
    }
}