using Module.Products.Core.Commands;
using Module.Products.Core.Entities;
using Module.Products.Core.Queries;

namespace Module.Products.Core.Abstractions
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(GetProductByIdQuery request, CancellationToken cancellationToken);
        Task<Guid> Create(CreateProductCommand request, CancellationToken cancellationToken);
        Task<bool> Update(UpdateProductCommand request, CancellationToken cancellationToken);
        Task<bool> Delete(DeleteProductCommand request, CancellationToken cancellationToken);
    }
}
