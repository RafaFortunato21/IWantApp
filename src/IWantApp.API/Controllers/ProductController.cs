using IWantApp.Application.Contracts;
using IWantApp.Application.DTO;
using IWantApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IWantApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpPost(Name = "CreateProduct")]
        public async Task<ActionResult<ProductResponse>> Post(ProductRequest model)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            var product = await _productService.Add(model, userId);

            if (product == null) return BadRequest();


            return Ok(product);
        }

        [HttpGet(Name = "GetProducts")]
        public async Task<ActionResult<ProductResponse>> Get()
        {
            var products = await _productService.GetProducts();
            
            if (products == null) return NotFound();

            return Ok(products);
        }
    }
}
