using System;
using System.Collections.Generic;

namespace FrontEnd.DTOs.Item
{
    public class FronEndOrderDto
    {
        public int CustomerId { get; set; }

        public string CustomerFullName { get; set; }

        public DateTime OrderTimeStamp { get; set; }

        public double TotalPrice { get; set; }

        public List<int> ItemsIds { get; set; }

        public int DeliveryAddress { get; set; }

        public string ContancPhoneNumber { get; set; }
    }
}
