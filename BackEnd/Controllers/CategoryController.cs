using BackEnd.Model;
using BackEnd.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoriesService _categoryService;

        public CategoryController(ICategoriesService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponce<List<Category>>>> GetItemsFromCategory()
        {
            return Ok(await _categoryService.GetAllCategories());
        }
    }
}
