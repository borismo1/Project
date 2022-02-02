using AutoMapper;

namespace BackEnd.Service
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;

        public UserService(IMapper mapper) 
        {
            _mapper = mapper;
        
        }
    }
}
