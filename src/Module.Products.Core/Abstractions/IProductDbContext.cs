using Microsoft.EntityFrameworkCore;
using Module.Products.Core.Entities;

namespace Module.Products.Core.Abstractions
{
    public interface IProductDbContext
    {
        public DbSet<Product> Products { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
