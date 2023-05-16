using entities;
using Repository;
using Zxcvbn;


namespace Service
{
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)=>_orderRepository = orderRepository;


        public async Task<Order> AddOrder(Order newOrder)
        {
            List<int> productIds = newOrder.OrderItems.Select(item => item.ProuctId).ToList();
            int orderSum = await _orderRepository.getOrderPrice(newOrder.Id);
            if (orderSum != newOrder.Sum)
            {
                throw new InvalidOperationException("Dont change the order sum!!!");
            }
            
            return await _orderRepository.AddOrder(newOrder);
        }


        public async Task<List<Order>> GetAllOrders() => await _orderRepository.GetAllOrders();






    }
}
