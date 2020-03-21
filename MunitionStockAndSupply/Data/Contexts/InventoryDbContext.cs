using Microsoft.EntityFrameworkCore;
using MunitionStockAndSupply.Models;

namespace MunitionStockAndSupply.Data.Contexts
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options) { }

        public DbSet<Inventory> Inventory { get; set; }
    }
}
