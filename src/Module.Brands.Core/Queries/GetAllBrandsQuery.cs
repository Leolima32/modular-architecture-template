using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Brands.Core.Abstractions;
using Module.Brands.Core.Entities;

namespace Module.Brands.Core.Queries
{
    public class GetAllBrandsQuery : IRequest<IEnumerable<Brand>>
    {
    }
    internal class GetAllBrandsHandler : IRequestHandler<GetAllBrandsQuery, IEnumerable<Brand>>
    {
        private readonly IBrandRepository _repo;
        public GetAllBrandsHandler(IBrandRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Brand>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAll();
        }
    }
}
