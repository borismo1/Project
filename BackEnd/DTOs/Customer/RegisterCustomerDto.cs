using Newtonsoft.Json;
namespace BackEnd.DTOs.Customer
{
    public class RegisterCustomerDto
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
