using Module.Categories.Core.Commands;
using Module.Categories.Core.Entities;
using Module.Categories.Core.Queries;

namespace Module.Categories.Core.Abstractions
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category> GetById(GetCategoryByIdQuery request, CancellationToken cancellationToken);
        Task<Guid> Create(CreateCategoryCommand request, CancellationToken cancellationToken);
        Task<bool> Update(UpdateCategoryCommand request, CancellationToken cancellationToken);
        Task<bool> Delete(DeleteCategoryCommand request, CancellationToken cancellationToken);
    }
}
