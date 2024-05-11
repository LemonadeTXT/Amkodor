using Amkodor.AddWindows;
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
    public partial class SuppliersPage : Page
    {
        private readonly SupplierConnectionService _supplierConnectionService;
        private readonly MaterialSupplierConnectionService _materialSupplierConnectionService;

        public SuppliersPage()
        {
            _supplierConnectionService = new SupplierConnectionService();
            _materialSupplierConnectionService = new MaterialSupplierConnectionService();

            InitializeComponent();

            LoadDatagrid();
        }

        private async void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var supplier = (Supplier)dataGridSuppliers.SelectedItem;

            if (supplier != null)
            {
                dataGridMaterialsSuppliers.ItemsSource = await _materialSupplierConnectionService.GetAllMaterialsSupBySupplierId(supplier.Id);
            }
        }

        private void ButtonAddSupplier_Click(object sender, RoutedEventArgs e)
        {
            new AddSupplierWindow(_supplierConnectionService).ShowDialog();
        }

        private void ButtonEditSupplier_Click(object sender, RoutedEventArgs e)
        {
            var supplier = (Supplier)dataGridSuppliers.SelectedItem;

            if (supplier != null)
            {
                new EditSupplierWindow(_supplierConnectionService, supplier).ShowDialog();
            }
        }

        private void ButtonDeleteSupplier_Click(object sender, RoutedEventArgs e)
        {
            var supplier = (Supplier)dataGridSuppliers.SelectedItem;

            if (supplier != null)
            {
                _supplierConnectionService.Delete(supplier);
            }
        }

        private async void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            dataGridSuppliers.ItemsSource = await _supplierConnectionService.GetAllSuppliers();

            dataGridMaterialsSuppliers.ItemsSource = null;
        }

        private async void LoadDatagrid()
        {
            dataGridSuppliers.ItemsSource = await _supplierConnectionService.GetAllSuppliers();
        }
    }
}
