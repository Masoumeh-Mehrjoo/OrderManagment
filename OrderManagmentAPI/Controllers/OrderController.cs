using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OrderManagmentAPI.Model;
using OrderManagmentAPI.Service.Dto;
using OrderManagmentAPI.Service.Interfaces;

namespace OrderManagmentAPI.Controllers
{
    [Route("Api/Order")]
    [ApiController]

    public class OrderController : ControllerBase
    {
        readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderDto>> GetOrders([FromQuery] OrderResourceParameter orderResourceParameters)
        {
            //if (orderResourceParameters == null)
            //{
            var AllOrders = _orderService.AllRows();
            return new JsonResult(AllOrders);
            //}
            //else
            //{
            //  var AllClients = _orderService.SearchedRows(orderResourceParameters);
            // return Ok(AllClients);
            //}
        }
        [HttpGet("{id}", Name = "GetOrderById")]
        public ActionResult GetOrderById(int Id)
        {
            var order = _orderService.FindById(Id);
            if (order == null)
            {
                return NotFound("This Order Id is not exist in database");
            }

            return Ok(order);
        }


        [HttpPost]

        public ActionResult<OrderDto> PostOrder(OrderForCreationDto orderForCreationDto)
        {
            var OrderToReturn = _orderService.InsertOrder(orderForCreationDto);
            return CreatedAtRoute("GetOrderById", new { Id = OrderToReturn.id }, OrderToReturn);

        }
        [HttpPatch("{id}")]
        public ActionResult PatriallyUpdateOrder(int Id, JsonPatchDocument<OrderForUpdateDto> patchDocument)
        {
            //try
            // {
            _orderService.EditOrder(Id, patchDocument);
            return NoContent();
            //}
            // catch (NotFoundException)
            // {
            //   return NotFound("Jason parameters are not Correct or this Client Id is not exist in database.");
            // }
        }

    }
}
