using Newtonsoft.Json;
using System.Collections.Generic;

namespace FrontEnd.Model
{
    public class Customer : IUser
    {
        ShopingCart ShopingCart { get; set; }
    }
}
