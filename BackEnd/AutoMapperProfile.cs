using AutoMapper;
using BackEnd.DTOs.Customer;
using BackEnd.DTOs.Item;
using BackEnd.Model;

namespace BackEnd
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {
            CreateMap<Customer, GetCustomerDto>();
            CreateMap<Customer, AddCustomerDto>();
            CreateMap<Customer, UpdateCustomerDto>();
            CreateMap<Customer, LoginCustomerDto>();
            CreateMap<Customer, RegisterCustomerDto>();

            CreateMap<Item, GetItemDto>();
        }

    }
}
