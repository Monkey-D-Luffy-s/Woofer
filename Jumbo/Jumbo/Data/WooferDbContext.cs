using Jumbo.Modals;
using Microsoft.EntityFrameworkCore;

namespace Jumbo.Data
{
    public class WooferDbContext : DbContext
    {
        public WooferDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Woofer> Woofers { get; set; }
    }
}
