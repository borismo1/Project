using FrontEnd.DTOs.Item;
using FrontEnd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FrontEnd.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailPage : ContentPage
    {
        private GetItemDto _selectedProduct;

        public ProductDetailPage(GetItemDto prodcut)
        {
            _selectedProduct = prodcut;

            InitializeComponent();
            LblName.Text = prodcut.Name;
            LblPrice.Text = prodcut.Price.ToString();
            LblDetail.Text = prodcut.Description;
            ImgProduct.Source = prodcut.Image;
        }

        private async void TapBack_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void TapAdd_Tapped(object sender, EventArgs e)
        {
            int counter = int.Parse(LblQty.Text);
            counter++;
            LblQty.Text = counter.ToString();
        }

        private void TapRemove_Tapped(object sender, EventArgs e)
        {
            int counter = int.Parse(LblQty.Text);
            if (counter > 0) 
            {
                counter--;
                LblQty.Text = counter.ToString();
            }

        }

        private async void TapAddToCart_Tapped(object sender, EventArgs e)
        {
            int counter = int.Parse(LblQty.Text);

            if (counter == 0)
                return;

            ShoppingCartItemDto exitingItem = ShoppingCart.Items.FirstOrDefault(i => i.Id == _selectedProduct.Id);
            if (exitingItem == null)
                ShoppingCart.Items.Add(new ShoppingCartItemDto(_selectedProduct, counter));
            else
                exitingItem.Qty++;


            await DisplayAlert("Shopping Cart Updated", "The selected product(s) we added to the cart successfully.", "Ok");
        }
    }
}