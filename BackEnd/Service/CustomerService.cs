using AutoMapper;
using BackEnd.DTOs.User;
using BackEnd.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;

        public CustomerService(IMapper mapper, DataContext context) 
        {
            _mapper = mapper;
            _dataContext = context;
        }

        public async Task<ServiceResponce<GetCustomerDto>> AddCustomer(AddCustomerDto newCusomter)
        {
            ServiceResponce<GetCustomerDto> responce = new ServiceResponce<GetCustomerDto>();
            Customer CustomersDb = _mapper.Map<Customer>(newCusomter);
            //check return type, maybe we can use for sevice responce
            await _dataContext.AddAsync(CustomersDb);
            CustomersDb = await _dataContext.Customers.FirstOrDefaultAsync(c => c.Id == CustomersDb.Id);
            responce.Data = _mapper.Map<GetCustomerDto>(CustomersDb);
            return responce;
        }

        public Task<ServiceResponce<bool>> DeleteCustomer(Guid id)
        {
            //save chaneges async
            throw new NotImplementedException();
        }

        public async Task<ServiceResponce<List<GetCustomerDto>>> GetAllCustomers()
        {
            ServiceResponce<List<GetCustomerDto>> responce = new ServiceResponce<List<GetCustomerDto>>();
            List<Customer> CustomersDb = await _dataContext.Customers.ToListAsync();
            responce.Data = CustomersDb.Select(c => _mapper.Map<GetCustomerDto>(c)).ToList();
            return responce;       
        }

        public async Task<ServiceResponce<GetCustomerDto>> GetCustomerById(Guid Id)
        {
            ServiceResponce<GetCustomerDto> responce = new ServiceResponce<GetCustomerDto>();
            Customer CustomersDb = await _dataContext.Customers.FirstOrDefaultAsync(c => c.Id == Id);
            responce.Data = _mapper.Map<GetCustomerDto>(CustomersDb);
            return responce;
        }

        public Task<ServiceResponce<GetCustomerDto>> UpdateCustomer(UpdateCustomerDto updatedCustomer)
        {
            //save chaneges async
            throw new NotImplementedException();
        }
    }
}
