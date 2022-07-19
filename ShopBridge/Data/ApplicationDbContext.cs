using Microsoft.EntityFrameworkCore;
using ShopBridge.Models;

namespace ShopBridge.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Product { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
