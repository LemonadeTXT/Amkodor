using Amkodor.ConnectionServices;
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
using System.Windows.Shapes;

namespace Amkodor.AddWindows
{
    public partial class AddWarehouseWindow : Window
    {
        private readonly WarehouseConnectionService _warehouseConnectionService;

        public AddWarehouseWindow(WarehouseConnectionService warehouseConnectionService)
        {
            _warehouseConnectionService = warehouseConnectionService;

            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text != string.Empty)
            {
                _warehouseConnectionService.Add(new Warehouse { Name = textBoxName.Text.Trim() });

                Close();
            }
        }
    }
}
