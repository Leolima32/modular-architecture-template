using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.Categories.Core.Commands;
using Module.Categories.Core.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Module.Categories.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    internal class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet] 
        public async Task<IActionResult> Get()
        {
            var products = await _mediator.Send(new GetAllCategoriesQuery());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _mediator.Send(new GetCategoryByIdQuery(id));
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteCategoryCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
