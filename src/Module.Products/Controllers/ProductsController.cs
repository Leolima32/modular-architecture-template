using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.Products.Core.Commands;
using Module.Products.Core.Queries;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Module.Products.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    internal class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet] 
        public async Task<IActionResult> Get()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _mediator.Send(new GetProductByIdQuery(id));
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteProductCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
