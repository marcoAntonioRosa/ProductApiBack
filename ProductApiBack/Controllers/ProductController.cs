using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductApiBack.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts()
        {
            return new List<Product>();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetSingleProduct()
        {
            return new Product();
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            return new Product();
        }

        [HttpPut]
        public async Task<ActionResult<Product>> EditProduct(Product product)
        {
            return new Product();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            return new Product();
        }
    }
}
