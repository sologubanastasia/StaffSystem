using StaffSystem.Application;
using StaffSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;
using StaffSystem.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews()
    .AddRazorRuntimeCompilation();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        // ❗ Переконайтеся, що StaffSystemDbContext - це правильна назва
        var context = services.GetRequiredService<StaffSystemDbContext>(); 
        
        Console.WriteLine("Applying database migrations...");
        
        // Цей метод створює таблиці (Company, Employee тощо)
        // якщо вони відсутні в базі даних.
        context.Database.Migrate(); 
        
        Console.WriteLine("Database migrations applied successfully.");

        // 💡 Місце для початкового наповнення бази даних (Seeding)
        // Якщо у вас є метод для додавання початкових даних:
        // SeedData.Initialize(context); 
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating or seeding the database.");
        // Залишаємо throw, щоб додаток не запускався без робочої схеми БД
        throw; 
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
