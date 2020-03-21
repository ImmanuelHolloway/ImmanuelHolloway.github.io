using Microsoft.EntityFrameworkCore;
using MunitionStockAndSupply.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MunitionStockAndSupply.Data.Contexts
{
    public class CartDbContext : DbContext
    {
        public CartDbContext(DbContextOptions<CartDbContext> options) : base(options) { }

        public DbSet<Cart> Cart { get; set; }
    }
}
