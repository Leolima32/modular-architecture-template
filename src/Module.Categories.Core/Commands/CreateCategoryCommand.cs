using MediatR;
using Module.Categories.Core.Abstractions;
using Module.Categories.Core.Entities;

namespace Module.Categories.Core.Commands
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }

    internal class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly ICategoryDbContext _context;
        public CreateCategoryCommandHandler(ICategoryDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var product = new Category() { Name = request.Name };
            await _context.Categories.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return product.Id;
        }
    }
}
