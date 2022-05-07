using System;
using System.Collections.Generic;

namespace FrontEnd.Model
{
    public class Order
    {
        public int Id { get; set; }
        
        public int CustomerId { get; set; }

        public string CustomerFullName { get; set; }

        public DateTime OrderTimeStamp { get; set; }

        public double TotalPrice { get; set; }

        public string ItemsIds { get; set; }

        public string DeliveryAddress { get; set; }

        public string ContancPhoneNumber { get; set; }

    }
}
