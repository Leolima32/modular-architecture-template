using MediatR;
using Module.Brands.Core.Abstractions;
using Module.Brands.Core.Entities;

namespace Module.Brands.Core.Commands
{
    public class CreateBrandCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }

    internal class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, Guid>
    {
        private readonly IBrandRepository _repo;
        public CreateBrandCommandHandler(IBrandRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Create(request, cancellationToken);
        }
    }
}
