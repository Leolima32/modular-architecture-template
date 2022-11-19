using MediatR;
using Module.Categories.Core.Abstractions;

namespace Module.Categories.Core.Commands
{
    public class UpdateCategoryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    internal class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly ICategoryDbContext _context;
        public UpdateCategoryCommandHandler(ICategoryDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var product = _context.Categories.Where(x => x.Id == request.Id).FirstOrDefault();
            product.Name = request.Name;
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
