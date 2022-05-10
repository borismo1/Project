using FrontEnd.Pages;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FrontEnd
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            string accessToken = Preferences.Get("accessToken", string.Empty);
            string role = Preferences.Get("role", string.Empty);

            if (string.IsNullOrWhiteSpace(accessToken))
                MainPage = new NavigationPage(new SignupPage());
            else
            {
                if (role == "Administrator")
                    MainPage = new NavigationPage(new AdminPage());
                else
                    MainPage = new NavigationPage(new HomePage());
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
