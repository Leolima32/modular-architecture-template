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
        private readonly IProductRepository _repo;
        public UpdateProductCommandHandler(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Update(request, cancellationToken);
        }
    }
}
