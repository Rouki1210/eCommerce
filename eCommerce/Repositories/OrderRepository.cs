using System.Security.Policy;
using eCommerce.Data;
using eCommerce.Models;
using eCommerce.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace eCommerce.Repositories
{
    public class OrderRepository : IOrderReponsitory
    {
        public ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context) 
        {  
            _context = context; 
        }
        
        public async Task<List<Order>> GetOrder()
        {
            var orders = await _context.Orders.ToListAsync();

            return orders;  
        }

        public async Task<Order> GetOrderById(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);

            return order;
        }

        public async Task<Order> AddOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return order;
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            var newOrder = await _context.Orders.FirstOrDefaultAsync(o => o.Id==order.Id);

            if (newOrder != null) 
            {
                newOrder.CustomerName = order.CustomerName;
                newOrder.ProductName = order.ProductName;
                newOrder.Price = order.Price;
                newOrder.Quantity = order.Quantity;
                newOrder.OrderDate = order.OrderDate;

                await _context.SaveChangesAsync();
            }

            return newOrder;
        }


        public async Task DeleteOrder(int id)
        {
            var DeleteOrder = await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);

            if (DeleteOrder == null)
            {
                throw new KeyNotFoundException($"Order with ID {id} not found.");
            }

            _context.Remove(DeleteOrder);
            await _context.SaveChangesAsync();
        }
    }
}
