using MediatR;
using Module.Categories.Core.Abstractions;

namespace Module.Categories.Core.Commands
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    internal class DeleteCategoryCommandHandler: IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly ICategoryDbContext _context;
        public DeleteCategoryCommandHandler(ICategoryDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var product = _context.Categories.Where(x => x.Id == request.Id).FirstOrDefault();
            if(product == null)
            {
                return false;
            }
            _context.Categories.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
