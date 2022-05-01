using FronEnd.Model;
using FrontEnd.Service;
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
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
        }

        private async void TapSignup_Tapped(object sender, EventArgs e)
        {
            ServiceResponce<int> resp = await ApiService.RegisterUser(EntUsername.Text,EntEmail.Text,EntPassword.Text);

            if (!resp.Success)
                await DisplayAlert("Failure", resp.Message, "Ok");
                
            else 
            {
                await DisplayAlert("Success", "User was registered successully", "Ok");
                await Navigation.PushModalAsync(new LoginPage());
            }
        }

        private async void SpanSignin_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}