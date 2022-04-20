using System;
using System.Collections.Generic;
using System.Linq;

namespace BackEnd.Model
{
    public class ShopingCart
    {
        public Guid CustomerID { get; set; }

        public List<Item> Items { get; set; }

        public double TotalPrice 
        {
            get 
            {
                return Items.Sum(i => i.Price);
            }
        }

        public ShopingCart(Guid customerID) 
        {
            CustomerID = customerID;
            Items = new List<Item>();
        }
    }
}
