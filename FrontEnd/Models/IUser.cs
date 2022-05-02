using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FrontEnd.Model
{
    public abstract class IUser
    {
        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }
    }
}
