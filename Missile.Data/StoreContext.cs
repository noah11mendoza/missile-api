using Missile.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Missile.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {}

        public DbSet<Item> Items { get; set; }
    }

}
