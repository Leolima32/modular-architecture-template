using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Products.Core.Abstractions;
using Module.Products.Core.Entities;

namespace Module.Products.Core.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
    internal class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductDbContext _context;
        public GetAllProductsHandler(IProductDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _context.Products.OrderBy(x => x.Id).ToListAsync();
            return products;
        }
    }
}
