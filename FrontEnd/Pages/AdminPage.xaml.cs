using FronEnd.Model;
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
    public partial class AdminPage : ContentPage
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private async void TapDeleteUser_Tapped(object sender, EventArgs e)
        {
            ServiceResponce<int> resp = await ApiService.DeleteCustomer(int.Parse(EntUserId.Text));

            if (resp.Success)
                await DisplayAlert("Success",$"User with ID:{resp.Data} was deleted.","Ok");
            else
                await DisplayAlert("Operation Failed", $"Failed to delete User with ID:{EntUserId.Text}", "Ok");
        }

        private async void TapDeleteItem_Tapped(object sender, EventArgs e)
        {
            ServiceResponce<int> resp = await ApiService.DeleteItem(int.Parse(EntItemId.Text));
            if (resp.Success)
                await DisplayAlert("Success", $"Item with ID:{resp.Data} was deleted.", "Ok");
            else
                await DisplayAlert("Operation Failed", $"Failed to delete Item with ID:{EntItemId.Text}", "Ok");
        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Preferences.Set("accessToken", string.Empty);
            Preferences.Set("userName", string.Empty);
            Preferences.Set("userId", string.Empty);
            Preferences.Set("expirationDate", string.Empty);

            Application.Current.MainPage = new NavigationPage(new SignupPage());
        }
    }
}