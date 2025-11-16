using Microsoft.EntityFrameworkCore;
using StaffSystem.Infrastructure.Data;

namespace StaffSystem.Infrastructure.Data;

public class StaffSystemDbContext : StaffSystemDbContext
{
    public StaffSystemDbContext(DbContextOptions<StaffSystemDbContext> options):base(options){}

    public DbSet<Emloyee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Position> Positions { get; set; }
}