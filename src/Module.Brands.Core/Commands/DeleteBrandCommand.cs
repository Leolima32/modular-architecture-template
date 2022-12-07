using MediatR;
using Module.Brands.Core.Abstractions;

namespace Module.Brands.Core.Commands
{
    public class DeleteBrandCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    internal class DeleteBrandCommandHandler: IRequestHandler<DeleteBrandCommand, bool>
    {
        private readonly IBrandDbContext _context;
        public DeleteBrandCommandHandler(IBrandDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var product = _context.Brands.Where(x => x.Id == request.Id).FirstOrDefault();
            if(product == null)
            {
                return false;
            }
            _context.Brands.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
