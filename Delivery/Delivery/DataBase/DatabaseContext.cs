using Delivery.Model;
using Microsoft.EntityFrameworkCore;

namespace Delivery.DataBase;

internal class DatabaseContext : DbContext
{
    public DbSet<Order>Orders { get; set; }
    public DatabaseContext() => Database.EnsureCreated();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Delivery.db");
    }
}
