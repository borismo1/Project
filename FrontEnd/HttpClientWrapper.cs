using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FrontEnd
{
    public static class HttpClientWrapper
    {
        private static readonly string LoopBackIp = "10.0.2.2";
        private static readonly string LoopBackPort = "5001";



        public static HttpClient GetHttpClientForLocalAndroidTesting(string AuthToken = "") 
        {
            HttpClient client = new HttpClient(GetInsecureHandler());

            if (!string.IsNullOrWhiteSpace(AuthToken))
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AuthToken);

            client.BaseAddress = new Uri($"https://{LoopBackIp}:{LoopBackPort}");
            return client;
        }

        public static HttpClient GetHttpForiOSLocalTesting()
        {
            HttpClient client = new HttpClient(GetInsecureHandler());
            client.BaseAddress = new Uri($"https://127.0.0.1:{LoopBackPort}");
            return client;
        }

        public static StringContent GetStringContent(object source) 
        {
            string jsonCustomer = JsonConvert.SerializeObject(source, Formatting.Indented);
            StringContent content = new StringContent(jsonCustomer, Encoding.UTF8, "application/json");
            return content;
        }


        public async static Task<R> PostToLocalApi<R,P>(string route,P payload, string JWT = "") 
        {
            HttpResponseMessage resp;
            StringContent content = GetStringContent(payload);
            using (HttpClient client = GetHttpClientForLocalAndroidTesting(AuthToken: JWT)) 
                resp = await client.PostAsync(route, content);

            R responseBody = JsonConvert.DeserializeObject<R>(await resp.Content.ReadAsStringAsync());

            return responseBody;
        }

        public async static Task<R> GetFromLocalApi<R>(string route, string JWT = "")
        {
            HttpResponseMessage resp;
            using (HttpClient client = GetHttpClientForLocalAndroidTesting(AuthToken: JWT))
                resp = await client.GetAsync(route);

            R responseBody = JsonConvert.DeserializeObject<R>(await resp.Content.ReadAsStringAsync());

            return responseBody;
        }

        public async static Task<R> DeleteToLocalApi<R>(string route, string JWT = "")
        {
            HttpResponseMessage resp;
            using (HttpClient client = GetHttpClientForLocalAndroidTesting(AuthToken: JWT))
                resp = await client.DeleteAsync(route);

            R responseBody = JsonConvert.DeserializeObject<R>(await resp.Content.ReadAsStringAsync());

            return responseBody;
        }

        //used for ignoring unsigned ssl sertificate 
        private static HttpClientHandler GetInsecureHandler() 
        {
            HttpClientHandler InsecureHandler = new HttpClientHandler();
            InsecureHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };

            return InsecureHandler;
        }

    }
}
