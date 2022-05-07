using BackEnd.Model;
using BackEnd.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _ordersService;

        public OrdersController(IOrderService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpPost("Add")]
        public async Task<ActionResult<ServiceResponce<int>>> AddNewOrder(Order order)
        {
            return Ok(await _ordersService.AddOrder(order));
        }

    }
}
