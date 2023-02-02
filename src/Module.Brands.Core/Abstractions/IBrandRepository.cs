using Module.Brands.Core.Commands;
using Module.Brands.Core.Entities;
using Module.Brands.Core.Queries;

namespace Module.Brands.Core.Abstractions
{
    public interface IBrandRepository
    {
        Task<IEnumerable<Brand>> GetAll();
        Task<Brand> GetById(GetBrandByIdQuery request, CancellationToken cancellationToken);
        Task<Guid> Create(CreateBrandCommand request, CancellationToken cancellationToken);
        Task<bool> Update(UpdateBrandCommand request, CancellationToken cancellationToken);
        Task<bool> Delete(DeleteBrandCommand request, CancellationToken cancellationToken);
    }
}
