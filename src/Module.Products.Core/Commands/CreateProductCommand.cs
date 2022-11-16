using MediatR;
using Module.Products.Core.Abstractions;
using Module.Products.Core.Entities;

namespace Module.Products.Core.Commands
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }

    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductDbContext _context;
        public CreateProductCommandHandler(IProductDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product() { Name = request.Name };
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return product.Id;
        }
    }
}
