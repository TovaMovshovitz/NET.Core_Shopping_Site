using entities;
using Repository;
using Zxcvbn;


namespace Service
{
    public class OrderService : IOrderService
    {
        IOrderRepository _orderRepository;
        IProductRepository _productRepository;
        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<Order> AddOrder(Order newOrder)
        {
            int orderSum = 0;

            foreach (var item in newOrder.OrderItems)
            {
                Product product = await _productRepository.GetProductById(item.ProductId);
                orderSum += product.Price * item.Quantity;
            }

            if (orderSum != newOrder.Sum)
            {
                throw new InvalidOperationException($"Attempt to change the sum of the order! order sum:{orderSum}, user send:{newOrder.Sum}");
            }
            
            return await _orderRepository.AddOrder(newOrder);
        }


        public async Task<List<Order>> GetAllOrders() => await _orderRepository.GetAllOrders();






    }
}
