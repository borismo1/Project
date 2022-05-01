using BackEnd.Model;
using System;
using System.Threading.Tasks;

namespace BackEnd.Data
{
    public interface IAuthRepository
    {

        Task<ServiceResponce<int>> Register(Customer customer, string password);

        Task<ServiceResponce<string>> Login(string username, string password);

        Task<ServiceResponce<bool>> CustomerExists(string username);

    }
}
