using Microsoft.AspNetCore.Mvc;

namespace Module.Products.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    internal class ProductsController : ControllerBase
    {
        [HttpGet] 
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put()
        {
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            return Ok();
        }
    }
}
