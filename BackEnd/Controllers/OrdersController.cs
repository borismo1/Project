using BackEnd.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        [HttpPost("Add")]
        public async Task<ActionResult<ServiceResponce<int>>> AddNewOrder(Order) 
        {
        
        }

    }
}
