using Microsoft.EntityFrameworkCore; // <--- ВИРІШУЄ CS0146 та CS0311
using StaffSystem.Domain.Entities; 

namespace StaffSystem.Infrastructure.Data
{
    // Обов'язково назвіть його StaffSystemDbContext
    public class StaffSystemDbContext : DbContext // <--- Успадкування від DbContext
    {
        public StaffSystemDbContext(DbContextOptions<StaffSystemDbContext> options)
            : base(options)
        {
        }

        // DbSets для всіх таблиць, які ми хочемо мігрувати
        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        
        // ВИПРАВЛЕНО: Було Emloyee, стало Employee
        public DbSet<Employee> Employees { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Налаштування для відповідності схемі PostgreSQL
            modelBuilder.HasDefaultSchema("public"); 

            // Налаштування імен таблиць з урахуванням регістру
            modelBuilder.Entity<Company>().ToTable("Company");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Position>().ToTable("Position");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            
            // Налаштування зв'язків та правил видалення (ON DELETE)
            
            // Company -> Department (CASCADE)
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Company)
                .WithMany() 
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
            
            // Employee -> Company (CASCADE)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Company)
                .WithMany()
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Cascade); 

            // Employee -> Department (RESTRICT)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany()
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict); 

            // Employee -> Position (RESTRICT)
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Position)
                .WithMany()
                .HasForeignKey(e => e.PositionId)
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}