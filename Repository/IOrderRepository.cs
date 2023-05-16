using entities;

namespace Repository
{
    public interface IOrderRepository
    {
        Task<Order> AddOrder(Order newOrder);
        Task<List<Order>> GetAllOrders();

        Task<int> getOrderPrice(int orderId);
    }
}