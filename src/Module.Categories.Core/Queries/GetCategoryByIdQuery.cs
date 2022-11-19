using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Categories.Core.Abstractions;
using Module.Categories.Core.Entities;

namespace Module.Categories.Core.Queries
{
    public class GetCategoryByIdQuery : IRequest<Category>
    {
        public Guid Id { get; set; }

        public GetCategoryByIdQuery(Guid id)
        {
            Id = id;
        }
    }

    internal class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category>
    {
        public ICategoryDbContext _context;
        public GetCategoryByIdQueryHandler(ICategoryDbContext context)
        {
            _context = context;
        }

        public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Categories.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
        }
    }
}
