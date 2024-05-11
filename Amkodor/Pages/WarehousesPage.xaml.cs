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
    public partial class WarehousesPage : Page
    {
        private readonly WarehouseConnectionService _warehouseConnectionService;
        private readonly MaterialConnectionService _materialConnectionService;

        public WarehousesPage()
        {
            _warehouseConnectionService = new WarehouseConnectionService();
            _materialConnectionService = new MaterialConnectionService();

            InitializeComponent();

            LoadDatagrid();
        }

        private async void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var warehouse = (Warehouse)dataGridWarehouses.SelectedItem;

            if (warehouse != null)
            {
                dataGridMaterials.ItemsSource = await _materialConnectionService.GetAllMaterialsByWarehouseId(warehouse.Id);
            }
        }

        private void ButtonAddWarehouse_Click(object sender, RoutedEventArgs e)
        {
            new AddWarehouseWindow(_warehouseConnectionService).ShowDialog();
        }

        private void ButtonEditWarehouse_Click(object sender, RoutedEventArgs e)
        {
            var warehouse = (Warehouse)dataGridWarehouses.SelectedItem;

            if (warehouse != null)
            {
                new EditWarehouseWindow(_warehouseConnectionService, warehouse).ShowDialog();
            }
        }

        private void ButtonDeleteWarehouse_Click(object sender, RoutedEventArgs e)
        {
            var warehouse = (Warehouse)dataGridWarehouses.SelectedItem;

            if (warehouse != null)
            {
                _warehouseConnectionService.Delete(warehouse);
            }
        }

        private async void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            dataGridWarehouses.ItemsSource = await _warehouseConnectionService.GetAllWarehouses();

            dataGridMaterials.ItemsSource = null;
        }

        private async void LoadDatagrid()
        {
            dataGridWarehouses.ItemsSource = await _warehouseConnectionService.GetAllWarehouses();
        }
    }
}
