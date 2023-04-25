using entities;

namespace Service
{
    public interface IOrderService
    {
        Task<Order> AddOrder(Order newOrder);
        Task<List<Order>> GetAllOrders();
    }
}