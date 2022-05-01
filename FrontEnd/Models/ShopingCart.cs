using System;
using System.Collections.Generic;
using System.Linq;

namespace FrontEnd.Model
{
    public class ShopingCart
    {
        public Customer Customer { get; set; }

        public List<Item> Items { get; set; }

        public double TotalPrice 
        {
            get 
            {
                return Items.Sum(i => i.Price);
            }
        }

        public ShopingCart(Customer customer) 
        {
            Customer = customer;
            Items = new List<Item>();
        }
    }
}
