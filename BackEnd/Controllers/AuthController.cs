using BackEnd.Data;
using BackEnd.DTOs.User;
using BackEnd.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthController(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponce<Guid>>> Register(CustomerRegisterDto request) 
        {
            var response = await _authRepo.Register(new Customer {Username = request.Username},request.Password);
        
            if(!response.Success)
                return BadRequest(response);

            return Ok(request);
        }
    }
}
