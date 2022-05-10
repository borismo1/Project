using AutoMapper;
using BackEnd.DTOs.Item;
using BackEnd.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using BackEnd.Utils;

namespace BackEnd.Service
{
    public class ItemService : IItemService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public ItemService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _dataContext = context;
        }

        public async Task<ServiceResponce<int>> DeleteItemById(int id)
        {
            ServiceResponce<int> responce = new ServiceResponce<int>();
            Item item = await _dataContext.Items.FirstOrDefaultAsync(i => i.Id == id);

            if (item == null)
            {
                responce.Success = false;
                responce.Data = id;
                responce.Message = "Item with that Id doesn't exist.";
                return responce;
            }

            _dataContext.Items.Remove(item);
            _dataContext.SaveChanges();

            responce.Data = id;
            return responce;
        }

        public async Task<ServiceResponce<List<GetItemDto>>> GetCategoryItems(int category)
        {
            ServiceResponce<List<GetItemDto>> responce = new ServiceResponce<List<GetItemDto>>();
            List<Item> itemDb = await _dataContext.Items.Where(i => i.Category == category).ToListAsync();
            responce.Data = itemDb.Select(c => _mapper.Map<GetItemDto>(c)).ToList();
            return responce;
        }

        public async Task<ServiceResponce<GetItemDto>> GetItemById(int id)
        {
            ServiceResponce<GetItemDto> responce = new ServiceResponce<GetItemDto>();
            Item itemDb = await _dataContext.Items.FirstOrDefaultAsync(i => i.IsTrending == true);
            responce.Data = _mapper.Map<GetItemDto>(itemDb);
            return responce;
        }

        public async Task<ServiceResponce<List<GetItemDto>>> GetTrandingItems()
        {
            ServiceResponce<List<GetItemDto>> responce = new ServiceResponce<List<GetItemDto>>();
            List<Item> itemDb = await _dataContext.Items.Where(i => i.IsTrending == true).ToListAsync();
            responce.Data = itemDb.Select(c => _mapper.Map<GetItemDto>(c)).ToList();
            return responce;
        }


    }
}
