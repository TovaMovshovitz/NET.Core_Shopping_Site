using entities;
using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get([FromQuery] string name=null, [FromQuery] List<int> categoryIds= null, [FromQuery] int minPrice=0, [FromQuery] int maxPrice=0)
        {
            List<Product> products = await _productService.GetAllProducts(name,categoryIds,minPrice,maxPrice);
            
            return products == null ? NoContent() : Ok(products);
        }


        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromBody] Product newProduct)
        {
            return Ok(await _productService.AddProduct(newProduct));
        }
    }
}
