using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Categories.Core.Abstractions;
using Module.Categories.Core.Entities;

namespace Module.Categories.Core.Queries
{
    public class GetAllCategoriesQuery : IRequest<IEnumerable<Category>>
    {
    }
    internal class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, IEnumerable<Category>>
    {
        private readonly ICategoryRepository _repo;
        public GetAllCategoriesHandler(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAll();
        }
    }
}
