using MediatR;
using Microsoft.EntityFrameworkCore;
using Module.Categories.Core.Abstractions;
using Module.Categories.Core.Entities;

namespace Module.Categories.Core.Queries
{
    public class GetCategoryByIdQuery : IRequest<Category>
    {
        public Guid Id { get; set; }

        public GetCategoryByIdQuery(Guid id)
        {
            Id = id;
        }
    }

    internal class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category>
    {
        private readonly ICategoryRepository _repo;
        public GetCategoryByIdQueryHandler(ICategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetById(request, cancellationToken);
        }
    }
}
