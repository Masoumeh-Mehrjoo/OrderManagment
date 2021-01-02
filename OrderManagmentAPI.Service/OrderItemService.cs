using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using OrderManagmentAPI.Model;
using OrderManagmentAPI.Model.Repository;
using OrderManagmentAPI.Service.Dto;
using OrderManagmentAPI.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagmentAPI.Service
{
    public class OrderItemService : IOrderItemService

    {
        private readonly IMapper _mapper;
        IOrderItemRepository _orderItemRepository;
        public OrderItemService(IOrderItemRepository orderItemRepository,IMapper mapper  )
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _orderItemRepository = orderItemRepository ?? throw new ArgumentNullException(nameof(orderItemRepository));

        }
        public IEnumerable<OrderItemDto> AllRows()
        {
            throw new NotImplementedException();
        }

        public void DeleteOrderItem(int Id)
        {
            throw new NotImplementedException();
        }

        public void EditOrderItem(int OrderItemId, JsonPatchDocument<OrderItemForUpdate> patchDocument)
        {
            throw new NotImplementedException();
        }

        public OrderItemDto FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public OrderItemDto InsertOrderItem(int orderId,OrderItemForCreation OrderItem)
        {
            var RepOrderItem = _mapper.Map<OrderItem>(OrderItem);
            _orderItemRepository.InsertByOrderId(orderId,RepOrderItem);

            var OrderItemToReturn = _mapper.Map<OrderItemDto>(RepOrderItem);
            return OrderItemToReturn;

        }

        public IEnumerable<OrderItemDto> SearchedRows(OrderItemResourceParameter OrderItemResourceParameter)
        {
            throw new NotImplementedException();
        }
    }
}
