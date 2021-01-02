using OrderManagmentAPI.Model;
using OrderManagmentAPI.Model.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagmentAPI.Repository
{
    public class OrderItemRepository : IOrderItemRepository

    {
        private OrderContext _context;
        public OrderItemRepository(OrderContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }
        public IEnumerable<OrderItem> AllRows()
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public void Edit(OrderItem entity)
        {

            throw new NotImplementedException();
        }

        public OrderItem findbyId(int Id)
        {
            throw new NotImplementedException();
        }

        public void Insert(OrderItem entity)
        {
            _context.OrderItems.Add(entity);
            _context.SaveChanges();
        }

        public OrderItem InsertByOrderId(int OrderId, OrderItem entity)
        {
            entity.OrderId = OrderId;
            Insert(entity);
            return (entity);
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderItem> SearchedRows(OrderItemResourceParameter parameter)
        {
            throw new NotImplementedException();
        }
    }
}
