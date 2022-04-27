using BackEnd.DTOs.User;
using BackEnd.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Service
{
    public interface ICustomerService
    {
        Task<ServiceResponce<List<GetCustomerDto>>> GetAllCustomers();

        Task<ServiceResponce<GetCustomerDto>> GetCustomerById(Guid id);

        Task<ServiceResponce<GetCustomerDto>> AddCustomer(AddCustomerDto newCusomter);

        Task<ServiceResponce<GetCustomerDto>> UpdateCustomer(UpdateCustomerDto updatedCustomer);

        Task<ServiceResponce<bool>> DeleteCustomer(Guid id);
    }
}
