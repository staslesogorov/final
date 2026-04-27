using api.Models;
using Microsoft.EntityFrameworkCore;
namespace api.Data;

public class AppDb : DbContext
{
    static AppDb()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder o) =>
        o.UseNpgsql("Host=localhost;Port=5432;Database=DBVENDING;Username=staslesogorov;Password=2505");

    public DbSet<Product> Products { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<User> Users { get; set; }  
    public DbSet<VendingMachine> VendingMachines { get; set; }
}
