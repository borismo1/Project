using System;
using System.Collections.Generic;
using System.Text;

namespace FrontEnd.Models
{
    public class Token
    {
        public string AccessToken { get; set; }

        public int Id { get; set; }

        public string UserName { get; set; }

        public DateTime ExpirationTime { get; set; }
    }
}
