using Microsoft.EntityFrameworkCore;
using Module.Brands.Core.Abstractions;
using Module.Brands.Core.Entities;
using Shared.Infrastructure.Persistence;

namespace Module.Brands.Infrastructure.Persistence
{
    internal class BrandDbContext : ModuleDbContext, IBrandDbContext
    {
        public BrandDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
