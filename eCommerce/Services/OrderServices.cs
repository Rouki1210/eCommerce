﻿using eCommerce.Models;
using eCommerce.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace eCommerce.Services
{
    public class OrderServices : IOrderService
    {
        private readonly IOrderReponsitory _orderReponsitory;
        public OrderServices(IOrderReponsitory orderReponsitory)
        {
            _orderReponsitory = orderReponsitory;
        }

        public async Task<List<Order>> GetAllListOrders()
        {
            return await _orderReponsitory.GetOrder();
        }

        public async Task<Order> GetOrderById(int id)
        {
            if (id == 0) 
            {
                throw new ArgumentException("Invalid order ID");
            }

            return await _orderReponsitory.GetOrderById(id);
        }

        public async Task<Order> GetOrderByCustomer(string CustomerName)
        {
            if (CustomerName == null)
            {
                throw new ArgumentException("Not found this customer");
            }

            return await _orderReponsitory.GetOrderByCustom(CustomerName);
        }
        public async Task<Order> AddOrder(Order order)
        {
            var newOrder = await _orderReponsitory.AddOrder(order);
            return newOrder;
        }

        public async Task<Order> UpdateOrder(Order order)
        {
            var updateOrder = await _orderReponsitory.UpdateOrder(order);
            return updateOrder;
        }

        public async Task DeleteOrder(int id)
        {
            if (id <= 0)
            {
                throw new AggregateException("");
            }

            await _orderReponsitory.DeleteOrder(id);
        }
    }
}
