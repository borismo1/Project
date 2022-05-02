using BackEnd.Data;
using BackEnd.DTOs.Customer;
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
        public async Task<ActionResult<ServiceResponce<int>>> Register(RegisterCustomerDto request) 
        {
            var response = await _authRepo.Register
            (
                new Customer 
                {
                    Username = request.Username,
                    Email = request.Email
                },
                request.Password
            );
        
            if(!response.Success)
                return BadRequest(response);

            return Ok(response);
        }


        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponce<string>>> Login(LoginCustomerDto request)
        {
            var response = await _authRepo.Login(request.Username, request.Password);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

    }
}
