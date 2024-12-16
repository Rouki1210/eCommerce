using eCommerce.Models;

namespace eCommerce.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetAllListOrders();

        Task<Order> GetOrderById(int id);

        Task<Order> AddOrder(Order order);

        Task<Order> UpdateOrder(Order order);

        Task DeleteOrder(int id);

    }
}
