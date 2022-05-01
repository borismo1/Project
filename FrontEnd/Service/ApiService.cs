using FronEnd.Model;
using FrontEnd.DTOs.Customer;
using FrontEnd.Model;
using FrontEnd.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FrontEnd.Service
{
    public static class ApiService
    {
        public static async Task<ServiceResponce<List<Item>>> GetTrendingItems() 
        {
            string trendingProductsRoute = "/Item/GetTrending";
            return await HttpClientWrapper.GetFromLocalApi<ServiceResponce<List<Item>>>(trendingProductsRoute);
        }


        public static async Task<ServiceResponce<int>> RegisterUser(string username, string email, string password) 
        {
            string registerUserRoute = "/Auth/Register";

            RegisterCustomerDto customer = new RegisterCustomerDto() 
            {
                Username = username,
                Email = email,
                Password = password
            };

            ServiceResponce<int> resp = await HttpClientWrapper.PostToLocalApi<ServiceResponce<int>, RegisterCustomerDto>(registerUserRoute,customer);
            if (resp.Success)
                Preferences.Set("userName", username);

            return resp;
        }

        public static async Task<ServiceResponce<string>> LoginUser(string username, string password)
        {
            string loginUserRoute = "/Auth/Login";

            LoginCustomerDto customer = new LoginCustomerDto()
            {
                Username = username,
                Password = password
            };

            ServiceResponce<string> resp = await HttpClientWrapper.PostToLocalApi<ServiceResponce<string>, LoginCustomerDto>(loginUserRoute, customer);

            if (resp.Success)
            {
                Token token = JsonConvert.DeserializeObject<Token>(resp.Data);
                Preferences.Set("accessToken", token.AccessToken);
                Preferences.Set("userName", token.UserName);
            }

            return resp;
        }

    }
}
