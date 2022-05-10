using FronEnd.Model;
using FrontEnd.DTOs.Item;
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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            string userName = Preferences.Get("userName", string.Empty);
            if (!string.IsNullOrWhiteSpace(userName))
                EntUserName.Text = userName;
        }

        private async void TapBack_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void TapLogin_Tapped(object sender, EventArgs e)
        {
            ServiceResponce<string> resp;

            if (IsAdmin.IsChecked)
                resp = await ApiService.LoginAdmin(EntUserName.Text, EntPassword.Text);
            else
                resp = await ApiService.LoginUser(EntUserName.Text, EntPassword.Text);


            if (!resp.Success)
                await DisplayAlert("Failure", resp.Message, "Ok");

            else 
            {
                ShoppingCart.Items = new List<ShoppingCartItemDto>();

                if (IsAdmin.IsChecked)
                    Application.Current.MainPage = new NavigationPage(new AdminPage());
                else
                    Application.Current.MainPage = new NavigationPage(new HomePage());
            }
            
        }
    }
}