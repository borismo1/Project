using System;
using System.Collections.Generic;

namespace BackEnd.Model
{
    public class Order
    {
        public Guid OrderId { get; set; }
        
        public Guid CustomerID { get; set; }

        public DateTime OrderTimeStamp { get; set; }

        public double Price { get; set; }

        public List<Item> Items { get; set; }

        private Order() { }

        public Order(ShopingCart cart)
        {
            OrderId = Guid.NewGuid();
            OrderTimeStamp = DateTime.Now;
            CustomerID = cart.CustomerID;
            Price = cart.TotalPrice;
            Items = cart.Items;
        }
    }
}
