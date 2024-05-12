using Amkodor.Common.Enums;
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
    public partial class AddMaterialWindow : Window
    {
        private readonly MaterialConnectionService _materialConnectionService;
        private readonly WarehouseConnectionService _warehouseConnectionService;

        private IEnumerable<Warehouse> Warehouses { get; set; }

        public AddMaterialWindow(MaterialConnectionService materialConnectionService)
        {
            _materialConnectionService = materialConnectionService;

            _warehouseConnectionService = new WarehouseConnectionService();

            InitializeComponent();

            LoadComboBoxes();
            LoadWarehouses();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text != string.Empty &&
                comboBoxType.SelectedItem != null &&
                comboBoxUnit.SelectedItem != null &&
                int.TryParse(textBoxCount.Text, out _) && 
                comboBoxWarehouse.SelectedItem != null)
            {
                var material = new Material
                {
                    Name = textBoxName.Text.Trim(),
                    Type = (TypeEnum)comboBoxType.SelectedItem,
                    Unit = (UnitEnum)comboBoxUnit.SelectedItem,
                    Count = int.Parse(textBoxCount.Text.Trim()),
                    WarehouseId = WarehouseNameToId(comboBoxWarehouse.SelectedItem.ToString()),
                };

                _materialConnectionService.Add(material);

                Close();
            }
        }

        private async void LoadComboBoxes()
        {
            comboBoxType.ItemsSource = Enum.GetValues(typeof(TypeEnum));
            comboBoxUnit.ItemsSource = Enum.GetValues(typeof(UnitEnum));
        }

        private async void LoadWarehouses()
        {
            Warehouses = await _warehouseConnectionService.GetAllWarehouses();

            var warehousesNames = new List<string>();

            foreach (var warehouse in Warehouses)
            {
                warehousesNames.Add(warehouse.Name);
            }

            comboBoxWarehouse.ItemsSource = warehousesNames;
        }

        private int WarehouseNameToId(string warehouseName)
        {
            foreach (var warehouse in Warehouses)
            {
                if (warehouse.Name == warehouseName)
                {
                    return warehouse.Id;
                }
            }

            return 0;
        }
    }
}
