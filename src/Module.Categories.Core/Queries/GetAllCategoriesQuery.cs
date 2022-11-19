using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Categories.Core.Abstractions;
using Module.Categories.Core.Entities;

namespace Module.Categories.Core.Queries
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<Category>>
    {
    }
    internal class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<Category>>
    {
        private readonly ICategoryDbContext _context;
        public GetAllCategoriesHandler(ICategoryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Categories.OrderBy(x => x.Id).ToListAsync();
            return products;
        }
    }
}
