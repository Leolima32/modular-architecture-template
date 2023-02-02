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
        private readonly ICategoryRepository _repo;
        public UpdateCategoryCommandHandler(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Update(request, cancellationToken);
        }
    }
}
