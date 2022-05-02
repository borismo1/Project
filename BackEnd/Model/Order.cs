using System;
using System.Collections.Generic;

namespace BackEnd.Model
{
    public class Order
    {
        public int Id { get; set; }
        
        public Customer Customer { get; set; }

        public DateTime OrderTimeStamp { get; set; }

        public double Price { get; set; }

        public List<Item> Items { get; set; }

        private Order() { }

    }
}
