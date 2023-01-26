using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Products.Core.Abstractions;
using Module.Products.Core.Entities;

namespace Module.Products.Core.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
    internal class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _repo;
        public GetAllProductsHandler(IProductRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAll();
        }
    }
}
