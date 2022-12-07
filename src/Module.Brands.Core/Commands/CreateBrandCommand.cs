using MediatR;
using Module.Brands.Core.Abstractions;
using Module.Brands.Core.Entities;

namespace Module.Brands.Core.Commands
{
    public class CreateBrandCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }

    internal class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, Guid>
    {
        private readonly IBrandDbContext _context;
        public CreateBrandCommandHandler(IBrandDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var product = new Brand() { Name = request.Name };
            await _context.Brands.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return product.Id;
        }
    }
}
