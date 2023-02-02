using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Brands.Core.Abstractions;
using Module.Brands.Core.Entities;

namespace Module.Brands.Core.Queries
{
    public class GetBrandByIdQuery : IRequest<Brand>
    {
        public Guid Id { get; set; }

        public GetBrandByIdQuery(Guid id)
        {
            Id = id;
        }
    }

    internal class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, Brand>
    {
        private readonly IBrandRepository _repo;
        public GetBrandByIdQueryHandler(IBrandRepository repo)
        {
            _repo = repo;
        }

        public async Task<Brand> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetById(request, cancellationToken);
        }
    }
}
