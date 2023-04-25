using entities;
using Repository;
using Zxcvbn;


namespace Service
{
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)=>_orderRepository = orderRepository;
        

        public async Task<Order> AddOrder(Order newOrder) => await _orderRepository.AddOrder(newOrder);


        public async Task<List<Order>> GetAllOrders() => await _orderRepository.GetAllOrders();






    }
}
