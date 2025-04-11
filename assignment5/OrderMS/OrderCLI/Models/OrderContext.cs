using Microsoft.EntityFrameworkCore;

namespace OrderCLI.Models;

public class OrderContext: DbContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Good> Goods { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("./Data/Orders.db");
}