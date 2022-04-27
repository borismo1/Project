using BackEnd.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BackEnd.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }


        public async Task<ServiceResponce<bool>> CustomerExists(string username)
        {
            if (await _context.Customers.AnyAsync(c => c.Username.ToLower().Equals(username.ToLower())))
                return new ServiceResponce<bool>() { Data = true };

            return new ServiceResponce<bool>() { Data = false };
        }

        public Task<ServiceResponce<string>> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponce<Guid>> Register(Customer customer, string password)
        {
            ServiceResponce<Guid> serviceResponce = new ServiceResponce<Guid>();

            if (CustomerExists(customer.Username).Result.Data == true)
            {
                serviceResponce.Success = false;
                serviceResponce.Message = "User already exists.";
                return serviceResponce;
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            customer.PasswordHash = passwordHash;
            customer.PasswordSalt = passwordSalt;   
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            serviceResponce.Data = customer.Id;
            return serviceResponce;
        }




        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) 
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

    }
}
