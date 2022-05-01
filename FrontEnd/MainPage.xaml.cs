using FronEnd.Model;
using FrontEnd.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FrontEnd
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void BtnSave_Clicked(object sender, EventArgs e) 
        {
            Preferences.Set("username", EnterUserName.Text);
        }

        private void BtnRetrieve_Clicked(object sender, EventArgs e)
        {
            string responce = Preferences.Get("username", string.Empty);
            LblUserName.Text = responce;
        }
    }
}
