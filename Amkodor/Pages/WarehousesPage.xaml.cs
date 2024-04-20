﻿using Amkodor.ConnectionServices;
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

        public WarehousesPage()
        {
            _warehouseConnectionService = new WarehouseConnectionService();

            InitializeComponent();

            LoadDatagrid();
        }

        private async Task LoadDatagrid()
        {
            dataGridWarehouses.ItemsSource = await _warehouseConnectionService.GetAllWarehouses();

            dataGridWarehouses.Columns[0].Header = "№";
            dataGridWarehouses.Columns[1].Header = "Название";
        }
    }
}
