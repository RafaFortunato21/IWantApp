using IWantApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace IWantApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetProduct")]
        public IActionResult Get()
        {
            return Ok("Funcionando");
        }
    }
}
