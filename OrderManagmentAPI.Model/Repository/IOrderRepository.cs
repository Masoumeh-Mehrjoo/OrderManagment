using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagmentAPI.Model.Repository
{
    public interface IOrderRepository : IRepository<Order, int, OrderResourceParameter>
    {
        public void InsertOrderWithOrderItem(Order order);
    }
}
