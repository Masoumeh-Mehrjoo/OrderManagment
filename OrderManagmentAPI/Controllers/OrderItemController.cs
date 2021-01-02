using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderManagmentAPI.Service;
using OrderManagmentAPI.Service.Dto;
using OrderManagmentAPI.Service.Interfaces;

namespace OrderManagmentAPI.Controllers
{
    [Route("api/Order/{OrderId}/OrderItems")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        IOrderItemService _OrderItemService;
        public OrderItemController(IOrderItemService orderItemService)
        {
            _OrderItemService = orderItemService;
        }
        [HttpPost]
        public ActionResult<OrderItemDto> PostOrderItem(
          int OrderId, OrderItemForCreation orderItem)
        {

            _OrderItemService.InsertOrderItem (OrderId,orderItem);
            return Ok();
        }

    }
}
