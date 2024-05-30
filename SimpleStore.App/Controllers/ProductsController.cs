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
            await _mediator.Send(command);
            return Ok();
        }
    }
}