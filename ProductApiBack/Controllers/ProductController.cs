using Microsoft.AspNetCore.Mvc;
using ProductApiBack.Services;

namespace ProductApiBack.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private IProductService _service;
        private ILoggerManager _logger;

        public ProductController(IProductService productService, ILoggerManager logger)
        {
            _service = productService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            return Ok(await _service.GetAllProducts());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetSingleProduct(int id)
        {
            return Ok(await _service.GetSingleProduct(id));
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            return Ok(await _service.CreateProduct(product));
        }

        [HttpPut]
        public async Task<ActionResult<Product>> EditProduct(Product product)
        {
            return Ok(await _service.EditProduct(product));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            return Ok(await _service.DeleteProduct(id));
        }
    }
}
