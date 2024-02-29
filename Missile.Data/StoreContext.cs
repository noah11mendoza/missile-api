﻿using Missile.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace Missile.Data
{
    public class StoreContext : DbContext
    {   
        public StoreContext(DbContextOptions<StoreContext> options)
            : base(options)
        {}

        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            DbInitializer.Initialize(builder);
        }
    }

}
