using BackEnd.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Service
{
    public class CategoriesService : ICategoriesService
    {
        private readonly DataContext _dataContext;

        public CategoriesService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ServiceResponce<List<Category>>> GetAllCategories()
        {
            ServiceResponce<List<Category>> resp = new ServiceResponce<List<Category>>();
            resp.Data = await _dataContext.Categories.ToListAsync();
            return resp;
        }
    }
}
