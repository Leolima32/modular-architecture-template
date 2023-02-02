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
        private readonly ICategoryRepository _repo;
        public DeleteCategoryCommandHandler(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _repo.Delete(request, cancellationToken);
        }
    }
}
