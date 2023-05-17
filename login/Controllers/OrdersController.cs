using entities;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Service;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrdersController(IOrderService orderService,IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> Get()
        {
            List<Order> orders = await _orderService.GetAllOrders();
            List<OrderDto> dtoOrders=_mapper.Map<List<Order>,List<OrderDto>> (orders);
            return orders == null ? NoContent() : Ok(dtoOrders);
        }


        // POST api/<CategoriesController>
        [HttpPost]
        public async Task<ActionResult<OrderDto>> Post([FromBody] OrderDto newOrderDto)
        {
            Order newOrder = _mapper.Map<OrderDto, Order>(newOrderDto);
            if (newOrder.Sum == 0)
                return BadRequest();
            Order order= await _orderService.AddOrder(newOrder);

            return Ok(_mapper.Map<Order, OrderDto>(order));


        }
    }
}
