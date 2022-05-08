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
    public partial class AdminPage : ContentPage
    {
        public AdminPage()
        {
            InitializeComponent();
        }

        private async void TapDeleteUser_Tapped(object sender, EventArgs e)
        {
            ServiceResponce<int> resp = await ApiService.DeleteCustomer(int.Parse(EntUserId.Text));
        }

        private async void TapDeleteItem_Tapped(object sender, EventArgs e)
        {
            ServiceResponce<int> resp = await ApiService.DeleteItem(int.Parse(EntItemId.Text));
        }
    }
}