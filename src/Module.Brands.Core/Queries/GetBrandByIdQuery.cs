using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Brands.Core.Abstractions;
using Module.Brands.Core.Entities;

namespace Module.Brands.Core.Queries
{
    public class GetBrandByIdQuery : IRequest<Brand>
    {
        public Guid Id { get; set; }

        public GetBrandByIdQuery(Guid id)
        {
            Id = id;
        }
    }

    internal class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, Brand>
    {
        public IBrandDbContext _context;
        public GetBrandByIdQueryHandler(IBrandDbContext context)
        {
            _context = context;
        }

        public async Task<Brand> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Brands.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
        }
    }
}
