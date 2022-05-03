using AutoMapper;
using BackEnd.Model;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Service
{
    public class OrderService : IOrderService
    {
        private readonly DataContext _dataContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;


        public OrderService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _dataContext = context;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<ServiceResponce<int>> AddOrder(Order order)
        {
            await _dataContext.Orders.AddAsync(order);
            await _dataContext.SaveChangesAsync();

            ServiceResponce<int> responce = new ServiceResponce<int>();
            responce.Data = order.Id;

            return responce;
        }
    }
}
