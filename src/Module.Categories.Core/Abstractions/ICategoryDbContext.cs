using Microsoft.EntityFrameworkCore;
using Module.Categories.Core.Entities;

namespace Module.Categories.Core.Abstractions
{
    public interface ICategoryDbContext
    {
        public DbSet<Category> Categories { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
