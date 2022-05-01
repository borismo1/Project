using System;

namespace FrontEnd.Model
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public double Price { get; set; }

        public bool IsTrending { get; set; }

        public int Category { get; set; }

        public int Inventory { get;}
    }
}
