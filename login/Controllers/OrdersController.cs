using entities;
using Microsoft.AspNetCore.Mvc;
using Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get()
        {
            List<Order> orders = await _orderService.GetAllOrders();
            return orders == null ? NoContent() : Ok(orders);
        }


        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] Order newOrder)
        {
           return Ok(await _orderService.AddOrder(newOrder));

        }
    }
}
