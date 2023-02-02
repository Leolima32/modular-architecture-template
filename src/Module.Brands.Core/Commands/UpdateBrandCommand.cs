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
        private readonly IBrandRepository _repo;
        public UpdateBrandCommandHandler(IBrandRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Update(request, cancellationToken);
        }
    }
}
