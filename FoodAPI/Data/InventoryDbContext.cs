using FoodAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodAPI.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Inventory> Inventories { get; set; }
    }
}
