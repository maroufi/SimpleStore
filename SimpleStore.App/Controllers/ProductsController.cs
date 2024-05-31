using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleStore.App.Products;

namespace SimpleStore.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.Failed) return BadRequest();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(IncreaseInventoryCountCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.Failed) return BadRequest();
            return Ok();
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> Get(long productId)
        {
            var result = await _mediator.Send(new ProductPriceQuery
            {
                ProductId = productId
            });
            if (result.Failed) return BadRequest();
            return Ok(result.Data);
        }
    }
}