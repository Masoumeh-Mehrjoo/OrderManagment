using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagmentAPI.Service.Dto
{
    public class OrderItemDto
    {
        public int id { get; set; }
        public float SoldPrice { get; set; }
        public int Count { get; set; }

    }
}
