using Microsoft.EntityFrameworkCore; 
using StaffSystem.Domain.Entities; 

namespace StaffSystem.Infrastructure.Data
{
    public class StaffSystemDbContext : DbContext 
    {
        public StaffSystemDbContext(DbContextOptions<StaffSystemDbContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public"); 

            modelBuilder.Entity<Company>().ToTable("Company");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Position>().ToTable("Position");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Company)
                .WithMany() 
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Company)
                .WithMany()
                .HasForeignKey(e => e.CompanyId)
                .OnDelete(DeleteBehavior.Cascade); 

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)
                .WithMany()
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Position)
                .WithMany()
                .HasForeignKey(e => e.PositionId)
                .OnDelete(DeleteBehavior.Restrict); 

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>().HasData(SeedData.DefaultCompany);
            modelBuilder.Entity<Department>().HasData(SeedData.Departments);
            modelBuilder.Entity<Position>().HasData(SeedData.Positions);    
            modelBuilder.Entity<Employee>().HasData(SeedData.Employees);    
        }
    }
}
