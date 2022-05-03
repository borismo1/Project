using FrontEnd.DTOs.Item;
using FrontEnd.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FrontEnd.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : ContentPage
    {
        public ObservableCollection<ShoppingCartItemDto> shoppingCartItems = new ObservableCollection<ShoppingCartItemDto>(ShoppingCart.Items);

        public CartPage()
        {
            InitializeComponent();
            ShoppingCartItemList.ItemsSource = shoppingCartItems;
            LblTotalPrice.Text = ShoppingCart.TotalPrice.ToString();
        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void TapClearCart_Tapped(object sender, EventArgs e)
        {
            ShoppingCart.Items = new List<ShoppingCartItemDto>();
            shoppingCartItems = new ObservableCollection<ShoppingCartItemDto>();
            ShoppingCartItemList.ItemsSource = shoppingCartItems;
            LblTotalPrice.Text = ShoppingCart.TotalPrice.ToString();
        }

        private async void BtnProceed_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new PlaceOrderPage());
        }
    }
}