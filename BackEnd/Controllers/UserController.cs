using BackEnd.Model;
using BackEnd.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("controller")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        [HttpGet("Get_By_{id}")]
        public async Task<ActionResult<IUser>> Get(int id) 
        {
            return Ok(); //async
        }

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

    }
} 
