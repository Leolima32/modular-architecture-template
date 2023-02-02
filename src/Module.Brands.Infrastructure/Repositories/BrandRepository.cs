using Microsoft.EntityFrameworkCore;
using Module.Brands.Core.Abstractions;
using Module.Brands.Core.Commands;
using Module.Brands.Core.Entities;
using Module.Brands.Core.Queries;

namespace Module.Brands.Infrastructure.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly IBrandDbContext _context;
        public BrandRepository(IBrandDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Create(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var Brand = new Brand() { Name = request.Name };
            await _context.Brands.AddAsync(Brand, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Brand.Id;
        }


        public async Task<bool> Delete(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            var Brand = _context.Brands.Where(x => x.Id == request.Id).FirstOrDefault();
            if (Brand == null)
            {
                return false;
            }
            _context.Brands.Remove(Brand);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<Brand>> GetAll()
        {
            var Brands = await _context.Brands.OrderBy(x => x.Id).ToListAsync();
            return Brands;
        }

        public async Task<Brand> GetById(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.Brands.Where(x => x.Id == request.Id).FirstOrDefaultAsync();
        }

        public async Task<bool> Update(UpdateBrandCommand request, CancellationToken cancellationToken)
        {
            var Brand = _context.Brands.Where(x => x.Id == request.Id).FirstOrDefault();
            Brand.Name = request.Name;
            return await _context.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
