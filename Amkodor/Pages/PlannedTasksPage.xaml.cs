using Amkodor.AddWindows;
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
    public partial class PlannedTasksPage : Page
    {
        private readonly ProductInManufConnectionService _productInManufConnectionService;

        public PlannedTasksPage()
        {
            _productInManufConnectionService = new ProductInManufConnectionService();

            InitializeComponent();

            LoadDataGrid();
        }

        private void ButtonAddPlannedProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAllowedMaterials_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAllowedEmployees_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonInfo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSend_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void LoadDataGrid()
        {
            dataGridPlannedProduct.ItemsSource = await _productInManufConnectionService.GetAllProductsInManufacturing();
        }
    }
}
