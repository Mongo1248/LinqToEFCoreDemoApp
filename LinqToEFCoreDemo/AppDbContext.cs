using Microsoft.EntityFrameworkCore;

class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=company.db");
    }
}
