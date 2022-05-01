using BackEnd.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Service
{
    public interface ICategoriesService
    {
        Task<ServiceResponce<List<Category>>> GetAllCategories();


    }
}
