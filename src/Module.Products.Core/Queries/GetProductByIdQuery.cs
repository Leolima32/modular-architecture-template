using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Products.Core.Abstractions;
using Module.Products.Core.Entities;

namespace Module.Products.Core.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public Guid Id { get; set; }

        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }
    }

    internal class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        public IProductDbContext _context;
        public GetProductByIdQueryHandler(IProductDbContext context)
        {
            _context = context;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
        }
    }
}
