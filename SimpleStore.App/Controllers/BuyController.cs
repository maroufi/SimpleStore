using MediatR;
using Microsoft.AspNetCore.Mvc;
using SimpleStore.App.Products;

namespace SimpleStore.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BuyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BuyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post(BuyCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.Failed) return BadRequest();
            return Ok();
        }
    }
}
