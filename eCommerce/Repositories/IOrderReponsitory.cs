using eCommerce.Models;

namespace eCommerce.Repositories
{
    public interface IOrderReponsitory
    {
        Task<List<Order>> GetOrder();
        Task<Order> GetOrderById(int id);

        Task<Order> AddOrder(Order order); 

        Task<Order> UpdateOrder(Order order);

        Task DeleteOrder(int id);
    }   
}
