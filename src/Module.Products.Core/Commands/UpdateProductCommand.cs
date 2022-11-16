using MediatR;
using Module.Products.Core.Abstractions;

namespace Module.Products.Core.Commands
{
    public class UpdateProductCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductDbContext _context;
        public UpdateProductCommandHandler(IProductDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _context.Products.Where(x => x.Id == request.Id).FirstOrDefault();
            product.Name = request.Name;
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
