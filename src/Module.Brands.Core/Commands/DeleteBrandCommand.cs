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
        private readonly IBrandRepository _repo;
        public DeleteBrandCommandHandler(IBrandRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Delete(request, cancellationToken);
        }
    }
}
