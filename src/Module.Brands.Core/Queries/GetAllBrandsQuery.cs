using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Brands.Core.Abstractions;
using Module.Brands.Core.Entities;

namespace Module.Brands.Core.Queries
{
    public class GetAllBrandsQuery : IRequest<IEnumerable<Brand>>
    {
    }
    internal class GetAllBrandsHandler : IRequestHandler<GetAllBrandsQuery, IEnumerable<Brand>>
    {
        private readonly IBrandDbContext _context;
        public GetAllBrandsHandler(IBrandDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Brand>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Brands.OrderBy(x => x.Id).ToListAsync();
            return products;
        }
    }
}
