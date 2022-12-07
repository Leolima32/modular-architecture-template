using MediatR;
using Module.Brands.Core.Abstractions;

namespace Module.Brands.Core.Commands
{
    public class UpdateBrandCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    internal class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, bool>
    {
        private readonly IBrandDbContext _context;
        public UpdateBrandCommandHandler(IBrandDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var product = _context.Brands.Where(x => x.Id == request.Id).FirstOrDefault();
            product.Name = request.Name;
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
