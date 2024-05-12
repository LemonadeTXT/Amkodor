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

namespace Amkodor.EditWindows
{
    public partial class EditMaterialWindow : Window
    {
        private readonly MaterialConnectionService _materialConnectionService;
        private readonly WarehouseConnectionService _warehouseConnectionService;

        private Material Material { get; set; }
        private IEnumerable<Warehouse> Warehouses { get; set; }

        public EditMaterialWindow(MaterialConnectionService materialConnectionService, Material material)
        {
            _materialConnectionService = materialConnectionService;

            _warehouseConnectionService = new WarehouseConnectionService();

            Material = material;

            InitializeComponent();

            LoadMaterial();
            LoadWarehouses();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text != string.Empty && 
                comboBoxType.SelectedItem != null && 
                comboBoxUnit.SelectedItem != null && 
                int.TryParse(textBoxCount.Text, out _))
            {
                Material.Name = textBoxName.Text.Trim();
                Material.Type = (TypeEnum)comboBoxType.SelectedItem;
                Material.Unit = (UnitEnum)comboBoxUnit.SelectedItem;
                Material.Count = int.Parse(textBoxCount.Text.Trim());

                if (comboBoxWarehouse.SelectedItem != null)
                {
                    Material.WarehouseId = WarehouseNameToId(comboBoxWarehouse.SelectedItem.ToString());
                }

                _materialConnectionService.Edit(Material);

                Close();
            }
        }

        private void LoadMaterial()
        {
            textBoxName.Text = Material.Name;

            comboBoxType.ItemsSource = Enum.GetValues(typeof(TypeEnum));
            comboBoxType.SelectedItem = Material.Type;

            comboBoxUnit.ItemsSource = Enum.GetValues(typeof(UnitEnum));
            comboBoxUnit.SelectedItem = Material.Unit;

            textBoxCount.Text = Material.Count.ToString();
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
