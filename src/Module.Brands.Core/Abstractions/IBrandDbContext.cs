using Microsoft.EntityFrameworkCore;
using Module.Brands.Core.Entities;

namespace Module.Brands.Core.Abstractions
{
    public interface IBrandDbContext
    {
        public DbSet<Brand> Brands { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
