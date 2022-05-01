using FronEnd.Model;
using FrontEnd.DTOs.Item;
using FrontEnd.Model;
using FrontEnd.Service;
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
    public partial class HomePage : ContentPage
    {
        public ObservableCollection<GetItemDto> TrandingProductCollection;


        public HomePage()
        {
            InitializeComponent();
            GetTrendingProducts();
            GetCategories();
        }

        private async void GetCategories()
        {
            ServiceResponce<List<Category>> resp = await ApiService.GetCategories();
        }

        private async void GetTrendingProducts()
        {
            ServiceResponce<List<GetItemDto>> resp = await ApiService.GetTrendingItems();

            if (resp.Success)
                TrandingProductCollection = new ObservableCollection<GetItemDto>(resp.Data);
            else
                TrandingProductCollection = new ObservableCollection<GetItemDto>();

            TrandingProducts.ItemsSource = TrandingProductCollection;
        }

        private async void TapMenu_Tapped(object sender, EventArgs e)
        {
            GridOverlay.IsVisible = true;
            await SlMenu.TranslateTo(0, 0, 400, Easing.Linear);
        }

        private async void TapCloseMenu_Tapped(object sender, EventArgs e)
        {
            await SlMenu.TranslateTo(-250, 0, 400, Easing.Linear);
            GridOverlay.IsVisible = false;

        }
    }
}