using BackEnd.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BackEnd.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public AuthRepository(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        public async Task<ServiceResponce<bool>> CustomerExists(string username)
        {
            if (await _context.Customers.AnyAsync(c => c.Username.ToLower().Equals(username.ToLower())))
                return new ServiceResponce<bool>() { Data = true };

            return new ServiceResponce<bool>() { Data = false };
        }

        public async Task<ServiceResponce<string>> Login(string username, string password)
        {
            ServiceResponce<string> responce = new ServiceResponce<string>();
            Customer customer = await _context.Customers.FirstOrDefaultAsync(c => c.Username.ToLower().Equals(username.ToLower()));
            if (customer == null)
            {
                responce.Success = false;
                responce.Message = "User not found.";
            }
            else if (!VerifyPasswordHash(password, customer.PasswordHash, customer.PasswordSalt)) 
            {
                responce.Success = false;
                responce.Message = "Wrong password.";
            }
            else
            {
                responce.Data = CreateToken(customer);
            }

            return responce;
        }

        public async Task<ServiceResponce<int>> Register(Customer customer, string password)
        {
            ServiceResponce<int> serviceResponce = new ServiceResponce<int>();

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

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt) 
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computeHash.Length; i++) 
                {
                    if (computeHash[i] != passwordHash[i])
                        return false;
                }
                return true;     
            }
        }

        private string CreateToken(Customer customer) 
        {
            List<Claim> claims = new List<Claim>() 
            {
                 new Claim(ClaimTypes.NameIdentifier, customer.Id.ToString()),
                 new Claim(ClaimTypes.Name, customer.Username)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor 
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);


            return tokenHandler.WriteToken(token);
        }

    }
}
