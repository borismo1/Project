using BackEnd.Model;
using BackEnd.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("controller")]
    public class UserController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        [HttpGet("Get_By_{id}")]
        public async Task<ActionResult<ServiceResponce<IUser>>> Get(Guid id) 
        {
            //ServiceResponce<IUser> serviceResponce = new ServiceResponce<IUser>();


            return Ok(await _customerService.GetCustomerById(id));
        }

        public UserController(ICustomerService userService)
        {
            _customerService = userService;
        }

    }
} 
