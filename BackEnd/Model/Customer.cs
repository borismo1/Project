using Newtonsoft.Json;
using System.Collections.Generic;

namespace BackEnd.Model
{
    public class Customer : IUser
    {
        [JsonProperty("Orders")]
        public ICollection<Order> Orders { get; set; }

        [JsonProperty("isBlocked")]
        public bool isBlocked { get; set; }
    }
}
