using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eCommerce.Data;
using eCommerce.Models;
using eCommerce.Services;
using NuGet.Protocol;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Http.HttpResults;

namespace eCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;

        //public OrdersController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var orders = await _orderService.GetAllListOrders();

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<Order> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderById(id);

            return order;
        }
        [HttpPost]
        public async Task<Order> AddOrder(Order order)
        {
            return await _orderService.AddOrder(order);
        }

        [HttpPut]
        public async Task<Order> UpdateOrder(Order order)
        {
            return await _orderService.UpdateOrder(order);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid order ID");
            }

            await _orderService.DeleteOrder(id);
            return NoContent();
           
        }
    }
}
