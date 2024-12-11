using ControleDeDoces.Models;
using Microsoft.EntityFrameworkCore;

namespace ControleDeDoces.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=ControleDeDoces.db");
        }
    }
}
