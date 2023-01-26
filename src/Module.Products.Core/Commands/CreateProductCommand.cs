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
        private readonly IProductRepository _repo;
        public CreateProductCommandHandler(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Create(request, cancellationToken);
        }
    }
}
