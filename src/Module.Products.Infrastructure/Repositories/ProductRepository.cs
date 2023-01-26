using Microsoft.EntityFrameworkCore;
using Module.Products.Core.Abstractions;
using Module.Products.Core.Commands;
using Module.Products.Core.Entities;
using Module.Products.Core.Queries;

namespace Module.Products.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductDbContext _context;
        public ProductRepository(IProductDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product() { Name = request.Name };
            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return product.Id;
        }


        public async Task<bool> Delete(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = _context.Products.Where(x => x.Id == request.Id).FirstOrDefault();
            if (product == null)
            {
                return false;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            var products = await _context.Products.OrderBy(x => x.Id).ToListAsync();
            return products;
        }

        public async Task<Product> GetById(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Products.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _context.Products.Where(x => x.Id == request.Id).FirstOrDefault();
            product.Name = request.Name;
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
