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

namespace Amkodor.EditWindows
{
    public partial class EditWarehouseWindow : Window
    {
        private readonly WarehouseConnectionService _warehouseConnectionService;

        private Warehouse Warehouse { get; set; }

        public EditWarehouseWindow(WarehouseConnectionService warehouseConnectionService, Warehouse warehouse)
        {
            _warehouseConnectionService = warehouseConnectionService;

            Warehouse = warehouse;

            InitializeComponent();

            LoadWarehouse();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text != string.Empty)
            {
                Warehouse.Name = textBoxName.Text.Trim();

                _warehouseConnectionService.Edit(Warehouse);

                Close();
            }
        }

        private void LoadWarehouse()
        {
            textBoxName.Text = Warehouse.Name;
        }
    }
}
