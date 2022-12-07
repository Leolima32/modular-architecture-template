using MediatR;
using Microsoft.AspNetCore.Mvc;
using Module.Brands.Core.Commands;
using Module.Brands.Core.Queries;

namespace Module.Brands.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    internal class BrandsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BrandsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet] 
        public async Task<IActionResult> Get()
        {
            var products = await _mediator.Send(new GetAllBrandsQuery());
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _mediator.Send(new GetBrandByIdQuery(id));
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateBrandCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateBrandCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteBrandCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
