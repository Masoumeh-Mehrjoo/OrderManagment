﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagmentAPI.Model.Repository
{
    public interface IOrderItemRepository : IRepository<OrderItem, int, OrderItemResourceParameter>
    {
        public IEnumerable<OrderItem> InsertByOrderId(int OrderId, OrderItem orderItem);
    }
}