using BackEnd.DTOs.Item;
using BackEnd.Model;
using BackEnd.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponce<GetItemDto>>> GetItem(int id)
        {
            return Ok(await _itemService.GetItemById(id));
        }

        [HttpGet("Category/{categoryId}")]
        public async Task<ActionResult<ServiceResponce<List<GetItemDto>>>> GetItemsFromCategory(int categoryId) 
        {
            return Ok(await _itemService.GetCategoryItems(categoryId));
        }

        [HttpGet("GetTrending")]
        public async Task<ActionResult<ServiceResponce<List<GetItemDto>>>> GetItemsFromCategory()
        {
            return Ok(await _itemService.GetTrandingItems());
        }

        [HttpDelete("Admin/Delete/{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<ServiceResponce<int>>> DeleteItem(int id)
        {
            return Ok(await _itemService.DeleteItemById(id));
        }

    }
}
