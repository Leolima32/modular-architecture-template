using Microsoft.EntityFrameworkCore;
using Module.Categories.Core.Abstractions;
using Module.Categories.Core.Commands;
using Module.Categories.Core.Entities;
using Module.Categories.Core.Queries;

namespace Module.Categories.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ICategoryDbContext _context;
        public CategoryRepository(ICategoryDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var Category = new Category() { Name = request.Name };
            await _context.Categories.AddAsync(Category, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Category.Id;
        }


        public async Task<bool> Delete(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var Category = _context.Categories.Where(x => x.Id == request.Id).FirstOrDefault();
            if (Category == null)
            {
                return false;
            }
            _context.Categories.Remove(Category);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var Categories = await _context.Categories.OrderBy(x => x.Id).ToListAsync();
            return Categories;
        }

        public async Task<Category> GetById(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Categories.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var Category = _context.Categories.Where(x => x.Id == request.Id).FirstOrDefault();
            Category.Name = request.Name;
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
