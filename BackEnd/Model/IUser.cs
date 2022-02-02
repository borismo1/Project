using Newtonsoft.Json;
using System;

namespace BackEnd.Model
{
    public abstract class IUser
    {
        [JsonProperty("Id")]
        public Guid Id { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("PasswordHash")]
        public byte[] PasswordHash { get; set; }

        [JsonProperty("PasswordSalt")]
        public byte[] PasswordSalt { get; set; }
    }
}
