using System.IO;
using Xamarin.Forms;

namespace FrontEnd.Model
{
    public class Category
    {
        public byte[] ImageBytes { get; set; }

        public string Name { get; set; }

        public int Id { get; set; }

        public ImageSource Image
        {
            get
            {
                return ImageSource.FromStream(() => new MemoryStream(ImageBytes));
            }
        }
    }
}
