using Microsoft.AspNetCore.JsonPatch;
using OrderManagmentAPI.Model;
using OrderManagmentAPI.Service.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagmentAPI.Service.Interfaces
{
    public interface IOrderItemService
    {
        public OrderItemDto InsertOrderItem(int orderId, OrderItemForCreation OrderItem);

        public IEnumerable<OrderItemDto> AllRows();

        public OrderItemDto FindById(int Id);

        public IEnumerable<OrderItemDto> SearchedRows(OrderItemResourceParameter OrderItemResourceParameter);

        public void DeleteOrderItem(int Id);

        public void EditOrderItem(int OrderItemId, JsonPatchDocument<OrderItemForUpdate> patchDocument);
    }
}
