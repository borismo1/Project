using BackEnd.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Service
{
    public interface IOrderService
    {
        Task<ServiceResponce<int>> AddOrder(Order order);


    }
}
