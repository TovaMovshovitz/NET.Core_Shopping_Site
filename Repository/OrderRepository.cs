using System.Text.Json;
using entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        MyShop213354335Context _MyShopContext;

        public OrderRepository(MyShop213354335Context myShopContext) => _MyShopContext = myShopContext;

        public async Task<Order> AddOrder(Order newOrder)
        {
            await _MyShopContext.Orders.AddAsync(newOrder);
            await _MyShopContext.SaveChangesAsync();
            return newOrder;
        }

        public async Task<List<Order>> GetAllOrders(){
        return await _MyShopContext.Orders.Include(order=>order.OrderItems).ToListAsync(); 
    }

        public async Task<int> getOrderPrice(int orderId)
        {
            
            List<OrderItem> items=await _MyShopContext.OrderItems.Include(item => item.Product).Where(i => i.OrderId == orderId).ToListAsync();
            int sum= items.Sum(item => item.Quantity*item.Product.Price);
            return sum;
        }
    }
}
