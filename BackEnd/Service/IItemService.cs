using BackEnd.DTOs.Item;
using BackEnd.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Service
{
    public interface IItemService
    {
        Task<ServiceResponce<GetItemDto>> GetItemById(int id);

        Task<ServiceResponce<List<GetItemDto>>> GetTrandingItems();

        Task<ServiceResponce<List<GetItemDto>>> GetCategoryItems(int category);

        Task<ServiceResponce<List<int>>> DeleteItemById(int id);
    }
}
