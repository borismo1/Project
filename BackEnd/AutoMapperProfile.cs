using AutoMapper;
using BackEnd.DTOs.User;
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
        }

    }
}
