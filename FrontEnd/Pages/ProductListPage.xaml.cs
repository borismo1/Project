using FronEnd.Model;
using FrontEnd.DTOs.Item;
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
    public partial class ProductListPage : ContentPage
    {
        public ObservableCollection<GetItemDto> Products;

        public ProductListPage(int categoryId, string categoryName)
        {
            InitializeComponent();
            LblCategoryName.Text = categoryName;
            GetProductsFromCategory(categoryId);
        }

        private async void TapBack_Tapped(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void GetProductsFromCategory(int categoryId) 
        {
            ServiceResponce<List<GetItemDto>> resp = await ApiService.GetProductsFromCategory(categoryId);

            if (resp.Success)
                Products = new ObservableCollection<GetItemDto>(resp.Data);
            else
                Products = new ObservableCollection<GetItemDto>();

            CategoryProducts.ItemsSource = Products;
        }
    }
}