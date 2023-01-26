using Microsoft.EntityFrameworkCore;
using Module.Products.Core.Abstractions;
using Module.Products.Core.Entities;
using Shared.Infrastructure.Persistence;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace Module.Products.Infrastructure.Persistence
{
    
    internal class ProductDbContext : ModuleDbContext, IProductDbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
