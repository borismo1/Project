using FronEnd.Model;
using FrontEnd.DTOs.Customer;
using FrontEnd.DTOs.Item;
using FrontEnd.Model;
using FrontEnd.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace FrontEnd.Service
{
    public static class ApiService
    {
        public static async Task<ServiceResponce<List<GetItemDto>>> GetTrendingItems() 
        {
            string trendingProductsRoute = "/Item/GetTrending";
            return await HttpClientWrapper.GetFromLocalApi<ServiceResponce<List<GetItemDto>>>(trendingProductsRoute);
        }

        public async static Task<ServiceResponce<List<Category>>> GetCategories()
        {
            string categoriesRoute = "/Category";
            return await HttpClientWrapper.GetFromLocalApi<ServiceResponce<List<Category>>>(categoriesRoute);
        }


        public async static Task<ServiceResponce<int>> AddOrder(Order order) 
        {
            string registerUserRoute = "/Orders/Add";

            string AuthToken = Preferences.Get("accessToken", string.Empty);

            ServiceResponce<int> resp = await HttpClientWrapper.PostToLocalApi<ServiceResponce<int>, Order>(registerUserRoute, order, AuthToken);

            return resp;
        }

        public async static Task<ServiceResponce<List<GetItemDto>>> GetProductsFromCategory(int categoryId)
        {
            string categoriesRoute = $"/Item/Category/{categoryId}";
            return await HttpClientWrapper.GetFromLocalApi<ServiceResponce<List<GetItemDto>>>(categoriesRoute);
        }

        public async static Task<ServiceResponce<int>> DeleteCustomer(int id)
        {
            string DeleteCustomerRoute = $"/Customer/Admin/Delete/{id}";
            string AuthToken = Preferences.Get("accessToken", string.Empty);
            return await HttpClientWrapper.DeleteToLocalApi<ServiceResponce<int>>(DeleteCustomerRoute, AuthToken);
        }

        public async static Task<ServiceResponce<int>> DeleteItem(int id)
        {
            string DeleteItemRoute = $"/Item/Admin/Delete/{id}";
            string AuthToken = Preferences.Get("accessToken", string.Empty);
            return await HttpClientWrapper.DeleteToLocalApi<ServiceResponce<int>>(DeleteItemRoute, AuthToken);
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

        public static async Task<ServiceResponce<int>> RegisterAdmin(string username, string email, string password)
        {
            string registerUserRoute = "/Auth/Admin/Register";

            Administrator admin = new Administrator()
            {
                Username = username,
                Email = email,
                Password = password
            };

            ServiceResponce<int> resp = await HttpClientWrapper.PostToLocalApi<ServiceResponce<int>, Administrator>(registerUserRoute, admin);
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

                JsonWebToken token = new JsonWebToken(resp.Data);

                Preferences.Set("accessToken", token.GetRawToken);
                Preferences.Set("userName", token.Payload.UserName);
                Preferences.Set("userId", int.Parse(token.Payload.CustomerId));
                Preferences.Set("expirationDate", token.Payload.ExpirationDate);
                Preferences.Set("role", token.Payload.Role);

            }

            return resp;
        }

        public static async Task<ServiceResponce<string>> LoginAdmin(string username, string password)
        {
            string loginUserRoute = "/Auth/Admin/Login";

            Administrator admin = new Administrator()
            {
                Username = username,
                Password = password
            };

            ServiceResponce<string> resp = await HttpClientWrapper.PostToLocalApi<ServiceResponce<string>, Administrator>(loginUserRoute, admin);

            if (resp.Success)
            {

                JsonWebToken token = new JsonWebToken(resp.Data);

                Preferences.Set("accessToken", token.GetRawToken);
                Preferences.Set("userName", token.Payload.UserName);
                Preferences.Set("userId", int.Parse(token.Payload.CustomerId));
                Preferences.Set("expirationDate", token.Payload.ExpirationDate);
                Preferences.Set("role", token.Payload.Role);

            }

            return resp;
        }

    }
}
