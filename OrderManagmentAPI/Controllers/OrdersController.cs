using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagmentAPI.Model;
using OrderManagmentAPI.Service.Dto;
using OrderManagmentAPI.Service.Interfaces;

namespace OrderManagmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        public ActionResult<OrderDto> GetOrders()
        {
               
            return Ok(new Order(DateTime.Now,new List<OrderItem>(),new Client()));
        }
    }
}
