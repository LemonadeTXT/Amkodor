using Amkodor.ConnectionServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Amkodor.Pages
{
    public partial class RequestMaterialSupplierPage : Page
    {
        private readonly RequestMaterialSupConnectionService _requestMaterialSupConnectionService;

        public RequestMaterialSupplierPage()
        {
            _requestMaterialSupConnectionService = new RequestMaterialSupConnectionService();

            InitializeComponent();

            LoadDatagrid();
        }

        private void ButtonEditProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDeleteProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void TextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Key == Key.Enter && !string.IsNullOrEmpty(textBoxSearch.Text))
            //{
            //    Search(textBoxSearch.Text);
            //}
            //else if (e.Key == Key.Enter && string.IsNullOrEmpty(textBoxSearch.Text))
            //{
            //    dataGridMaterialsSuppliers.ItemsSource = await _materialSupplierConnectionService.GetAllMaterialsSuppliers();
            //}
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonTransfer_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void Search(string value)
        {
            //if (textBoxSearch.Text != string.Empty)
            //{
            //    dataGridMaterialsSuppliers.ItemsSource = await _materialSupplierConnectionService.Search(value);
            //}
        }

        private async void LoadDatagrid()
        {
            dataGridRequestMaterialsSuppliers.ItemsSource = await _requestMaterialSupConnectionService.GetAllRequestMaterialsSups();
        }
    }
}
