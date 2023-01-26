using MediatR;
using Module.Products.Core.Abstractions;

namespace Module.Products.Core.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    internal class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _repo;
        public DeleteProductCommandHandler(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Delete(request, cancellationToken);
        }
    }
}
