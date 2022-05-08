using BackEnd.DTOs.Customer;
using BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Service
{
    public interface ICustomerService
    {
        Task<ServiceResponce<List<GetCustomerDto>>> GetAllCustomers();

        Task<ServiceResponce<GetCustomerDto>> GetCustomerById(int id);

        Task<ServiceResponce<bool>> DeleteCustomer(Guid id);
    }
}
