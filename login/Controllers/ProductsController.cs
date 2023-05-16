using AutoMapper;
using DTO;
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
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _mapper = mapper;
            _productService = productService;
        }
        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<ActionResult<List<ProductDto>>> Get([FromQuery] string? name, [FromQuery] List<int> categoryIds, [FromQuery] int? minPrice, [FromQuery] int? maxPrice)
        {
            List<Product> products = await _productService.GetAllProducts(name,categoryIds,minPrice,maxPrice);
            
            return products == null ? NoContent() : Ok(_mapper.Map<List<Product>,List<ProductDto>>(products));
        }


        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<ActionResult<ProductDto>> Post([FromBody] ProductDto newProductDto)
        {
            Product newProduct= await _productService.AddProduct(_mapper.Map<ProductDto,Product>(newProductDto));
            return Ok(_mapper.Map<Product, ProductDto>(newProduct));
        }
    }
}
