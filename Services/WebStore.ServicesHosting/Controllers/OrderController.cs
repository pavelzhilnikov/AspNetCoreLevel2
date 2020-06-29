﻿
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain;
using WebStore.Domain.DTO.Order;
using WebStore.Interfaces.Services;

namespace WebStore.ServiceHosting.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase, IOrderService
    {
        private readonly IOrderService _OrderService;

        public OrdersController(IOrderService OrderService) => _OrderService = OrderService;

        [HttpPost("{UserName}")]
        public Task<OrderDTO> CreateOrder(string UserName, [FromBody] CreateOrderModel OrderModel) => _OrderService.CreateOrder(UserName, OrderModel);

        [HttpGet("user/{UserName}")]
        public Task<IEnumerable<OrderDTO>> GetUserOrders(string UserName) => _OrderService.GetUserOrders(UserName);

        [HttpGet("{id}")]
        public Task<OrderDTO> GetOrderById(int id) => _OrderService.GetOrderById(id);
    }
}