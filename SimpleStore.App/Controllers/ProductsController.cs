using Microsoft.AspNetCore.Mvc;

namespace SimpleStore.App.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
    }
}