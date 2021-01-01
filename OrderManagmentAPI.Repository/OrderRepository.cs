using OrderManagmentAPI.Model;
using OrderManagmentAPI.Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderManagmentAPI.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private OrderContext _context;

        OrderItemRepository _orderItemRepository;
        public OrderRepository(OrderContext orderContext)
        {
            _context = orderContext;
            _orderItemRepository = new OrderItemRepository(_context);

        }
        public IEnumerable<Order> AllRows()
        {
            return _context.Orders.ToList();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Order entity)
        {
            foreach (var orderitem in entity.OrderItems)
            {
                entity = entity.EditOrderItem(orderitem);

                _orderItemRepository.Edit(orderitem);
            }
            _context.SaveChanges();

        }

        public Order findbyId(int Id)
        {
            return _context.Orders.Find(Id);
        }

        public void Insert(Order entity)
        {
            foreach (var orderitem in entity.OrderItems)
            {
                entity = entity.AddOrderItem(orderitem);

                _orderItemRepository.Insert(orderitem);
            }
            _context.Orders.Add(entity);
            _context.SaveChanges();

        }



        public void InsertOrderWithOrderItem(Order order)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> SearchedRows(OrderResourceParameter parameter)
        {
            throw new NotImplementedException();
        }
    }
}
