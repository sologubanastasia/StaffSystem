using StaffSystem.Application;
using StaffSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;
using StaffSystem.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// --- DI REGISTRATION TEST ---
// 1. MVC Controllers (Обов'язково)
builder.Services.AddControllersWithViews(); 

// 2. Application Layer (Тимчасово вимкнено)
// builder.Services.AddApplication(); 

// 3. Infrastructure Layer (АКТИВНИЙ ТЕСТ: містить DbContext)
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// ------------------- Міграції -------------------
try
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<StaffSystemDbContext>();
        Console.WriteLine("Applying database migrations...");
        context.Database.Migrate();
        Console.WriteLine("Database migrations applied successfully.");
    }
}
catch (Exception ex)
{
    // Якщо міграція не вдалася, додаток залогує помилку.
    app.Logger.LogError(ex, "An error occurred while applying migrations.");
}
// ------------------------------------------------

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication(); 
app.UseAuthorization();

// ТЕСТОВИЙ МАРШРУТ: Якщо Kestrel піднімається, він відповість тут.
app.MapGet("/", () => "Kestrel is alive! Infrastructure services are active."); 
app.MapGet("/health", () => "Kestrel is alive!"); 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();