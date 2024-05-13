using Amkodor.ConnectionServices;
using Amkodor.EditWindows;
using Amkodor.Models.Models;
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
    public partial class ProductsPage : Page
    {
        private readonly ProductConnectionService _productConnectionService;

        public ProductsPage()
        {
            _productConnectionService = new ProductConnectionService();

            InitializeComponent();

            LoadDatagrid();
        }

        private void ButtonEditProduct_Click(object sender, RoutedEventArgs e)
        {
            var product = (Product)dataGridProducts.SelectedItem;

            if (product != null)
            {
                new EditProductWindow(_productConnectionService, product).ShowDialog();
            }
        }

        private void ButtonDeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            var product = (Product)dataGridProducts.SelectedItem;

            if (product != null)
            {
                _productConnectionService.Delete(product);
            }
        }

        private async void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            dataGridProducts.ItemsSource = await _productConnectionService.GetAllProducts();
        }

        private async void TextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !string.IsNullOrEmpty(textBoxSearch.Text))
            {
                Search(textBoxSearch.Text);
            }
            else if (e.Key == Key.Enter && string.IsNullOrEmpty(textBoxSearch.Text))
            {
                dataGridProducts.ItemsSource = await _productConnectionService.GetAllProducts();
            }
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            Search(textBoxSearch.Text);
        }

        private async void Search(string value)
        {
            if (textBoxSearch.Text != string.Empty)
            {
                dataGridProducts.ItemsSource = await _productConnectionService.Search(value);
            }
        }

        private async void LoadDatagrid()
        {
            dataGridProducts.ItemsSource = await _productConnectionService.GetAllProducts();
        }
    }
}
