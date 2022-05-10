using BackEnd.Model;
using BackEnd.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponce<IUser>>> Get() 
        {
            int _id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);

            return Ok(await _customerService.GetCustomerById(_id));
        }

        [HttpDelete("Admin/Delete/{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<ServiceResponce<int>>> DeleteCustomer(int id)
        {
            return Ok(await _customerService.DeleteCustomerById(id));
        }

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

    }
} 
