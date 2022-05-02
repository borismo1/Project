using FrontEnd.DTOs.Item;
using System;
using System.Collections.Generic;

namespace FrontEnd.Model
{
    public class Order
    {
        public Guid OrderId { get; set; }
        
        public Customer Customer { get; set; }

        public DateTime OrderTimeStamp { get; set; }

        public double Price { get; set; }

        public List<GetItemDto> Items { get; set; }

        private Order() { }

        public Order(ShopingCart cart)
        {
            OrderId = Guid.NewGuid();
            OrderTimeStamp = DateTime.Now;
            Customer = cart.Customer;
            Price = cart.TotalPrice;
            Items = cart.Items;
        }
    }
}
