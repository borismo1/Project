using System.Collections.Generic;
using System.IO;
using Xamarin.Forms;

namespace FrontEnd.DTOs.Item
{
    public class GetItemDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public byte[] ImageBytes { get; set; }

        public double Price { get; set; }

        public int Category { get; set; }

        public ImageSource Image 
        { 
            get 
            {
                return ImageSource.FromStream(() => new MemoryStream(ImageBytes));
            } 
        }

    }
}
