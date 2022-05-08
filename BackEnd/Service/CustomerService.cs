using AutoMapper;
using BackEnd.DTOs.Customer;
using BackEnd.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BackEnd.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _dataContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomerService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor) 
        {
            _mapper = mapper;
            _dataContext = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private Guid GetUserId() => Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

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

        public async Task<ServiceResponce<GetCustomerDto>> GetCustomerById(int Id)
        {
            ServiceResponce<GetCustomerDto> responce = new ServiceResponce<GetCustomerDto>();
            Customer CustomersDb = await _dataContext.Customers.FirstOrDefaultAsync(c => c.Id == Id);
            responce.Data = _mapper.Map<GetCustomerDto>(CustomersDb);
            return responce;
        }

    }
}
