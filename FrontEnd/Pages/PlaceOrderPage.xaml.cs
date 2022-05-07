using FronEnd.Model;
using FrontEnd.Model;
using FrontEnd.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FrontEnd.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlaceOrderPage : ContentPage
    {
        public PlaceOrderPage()
        {
            InitializeComponent();
        }

        private async void BtnPlaceOrder_Clicked(object sender, EventArgs e)
        {
            Order order = new Order() 
            {
                ContancPhoneNumber = EntPhone.Text,
                CustomerFullName = EntName.Text,
                DeliveryAddress = EntPhone.Text,
                CustomerId = Preferences.Get("userId",0),
                ItemsIds = ShoppingCart.GetItemsIds,
                OrderTimeStamp = DateTime.Now,
                TotalPrice = ShoppingCart.TotalPrice
            };

            ServiceResponce<int> resp = await ApiService.AddOrder(order);

            if (!resp.Success)
                await DisplayAlert("Order failed", resp.Message, "Ok");
            else
            {
                ShoppingCart.Items = new List<DTOs.Item.ShoppingCartItemDto>();
                await DisplayAlert("Order successful", $"Order plcaed succfully, Order id:{resp.Data}.", "Ok");
                Application.Current.MainPage = new NavigationPage(new HomePage());             
            }
        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}