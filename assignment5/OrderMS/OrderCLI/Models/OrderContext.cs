using Microsoft.EntityFrameworkCore;

namespace OrderCLI.Models;

public class OrderContext: DbContext
{
    public DbSet<Good> Goods { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Order> Orders { get; set; }
    
    public string DbPath { get; }

    public OrderContext()
    {
        string basePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string dbPath = Path.Combine(basePath, "Orders.db");
        DbPath = dbPath;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source={DbPath}");
}