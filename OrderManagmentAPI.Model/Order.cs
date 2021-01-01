using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderManagmentAPI.Model
{
    public class Order : EntityBase<int>
    {
        public Order(DateTime issueDate, IEnumerable<OrderItem> orderItems, Client client)
        {
            IssueDate = issueDate;
            OrderItems = orderItems;
            this.client = client;
            SetCount();
            SetTotalValue();
            Tax = (float)(TotalPrice * 0.03);
            SetFinalPrice();
        }

        protected Order()
        {
        }

        public float TotalPrice { get;  set; }
        public void SetTotalValue()
        {
            TotalPrice = OrderItems.Select(x => x.TotalPrice).Sum();
        }

        public DateTime IssueDate { get; set; }
        public float Tax { get; private set; }
        public IEnumerable<OrderItem> OrderItems { get;  set; }

        public Order AddOrderItem(OrderItem newOrderItem)
        {
            List<OrderItem> orderItems = this.OrderItems.ToList();
            orderItems.Add(newOrderItem);
            SetCount();
            SetTotalValue();
            Tax = (float)(TotalPrice * 0.03);
            newOrderItem.OrderId = id;
            SetFinalPrice();
            return (this);
        }
        public Order EditOrderItem(OrderItem EditorderItem)
        {
            List<OrderItem> orderItems = this.OrderItems.ToList();
            orderItems.Add(EditorderItem);

            SetCount();
            SetTotalValue();

            Tax = (float)(TotalPrice * 0.03);
            EditorderItem.OrderId = id;

            SetFinalPrice();
            return (this);

        }

        public Client client { get; set; }
        public int Count { get;  set; }

        public void SetCount()
        {
            Count = OrderItems.Select(x => x.Count).Sum();
        }

        public float FinalPrice { get;  set; }

        public void SetFinalPrice()
        {
            FinalPrice = TotalPrice + Tax;
        }
    }
}
