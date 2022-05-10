using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace FrontEnd.Models
{
    public class JsonWebToken
    {
        private string _token;

        public JsonWebToken(string token)
        {
            _token = token;
        }

        public string GetRawToken
        { 
            get 
            { 
                return _token; 
            } 
        }

        public JsonWebTokenPayload Payload 
        {
            get 
            {
                string payloadBase64 = _token.Split('.')[1];
                string payloadBase64Padded = payloadBase64.PadRight(payloadBase64.Length + (4 - payloadBase64.Length % 4) % 4, '=');
                byte[] payloadBytes = Convert.FromBase64String(payloadBase64Padded);
                string payloadUTF8 = Encoding.UTF8.GetString(payloadBytes);
                return JsonConvert.DeserializeObject<JsonWebTokenPayload>(payloadUTF8);
            }
        }


    }


    public class JsonWebTokenPayload
    {
        [JsonProperty("nameid")]
        public string CustomerId { get; set; }

        [JsonProperty("unique_name")]
        public string UserName { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty("nbf")]
        public DateTime NotValidBefore { get; set; }


        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty("exp")]
        public DateTime ExpirationDate { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty("iat")]
        public DateTime IssuedAt { get; set; }   
    }

}
