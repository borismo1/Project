using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace FrontEnd.DTOs.Item
{
    public class ShoppingCartItemDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public byte[] ImageBytes { get; set; }

        public double Price { get; set; }

        public int Category { get; set; }

        public int Qty { get; set; }

        public double TotalPrice 
        {
            get 
            {
                return Qty * Price;
            }
        }

        public ImageSource Image
        {
            get
            {
                return ImageSource.FromStream(() => new MemoryStream(ImageBytes));
            }
        }

        public ShoppingCartItemDto(GetItemDto item, int qty) 
        {
            Id = item.Id;
            Name = item.Name;
            Description = item.Description;
            Price = item.Price;
            Category = item.Category;
            Qty = qty;
            ImageBytes = item.ImageBytes;          
        }

        public List<GetItemDto> GetItemDtoListFromCartDto()
        {
            List<GetItemDto> output = new List<GetItemDto>();
            for (int i = 0; i < Qty; i++)
            {
                GetItemDto getItemDto = new GetItemDto()
                {
                    Id = Id,
                    Name = Name,
                    Description = Description,
                    ImageBytes = ImageBytes,
                    Price = Price,
                    Category = Category
                };

                output.Add(getItemDto);
            }
            return output;
        }
    }
}
