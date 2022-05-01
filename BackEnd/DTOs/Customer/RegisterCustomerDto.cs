using Newtonsoft.Json;
namespace BackEnd.DTOs.Customer
{
    public class RegisterCustomerDto
    {
        [JsonProperty("Username")]
        public string Username { get; set; }

        [JsonProperty("Password")]
        public string Password { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }
    }
}
