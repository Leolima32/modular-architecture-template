using MediatR;
using Module.Products.Core.Abstractions;

namespace Module.Products.Core.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    internal class DeleteProductCommandHandler: IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductDbContext _context;
        public DeleteProductCommandHandler(IProductDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = _context.Products.Where(x => x.Id == request.Id).FirstOrDefault();
            if(product == null)
            {
                return false;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
