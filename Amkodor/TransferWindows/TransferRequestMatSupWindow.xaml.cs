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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Amkodor.TransferWindows
{
    public partial class TransferRequestMatSupWindow : Window
    {
        private readonly MaterialConnectionService _materialConnectionService;
        private readonly WarehouseConnectionService _warehouseConnectionService;

        private IEnumerable<Warehouse> Warehouses { get; set; }

        private RequestMaterialSupplier RequestMaterialSupplier { get; set; }

        public bool IsSuccessful { get; set; }

        public TransferRequestMatSupWindow(RequestMaterialSupplier requestMaterialSupplier)
        {
            _materialConnectionService = new MaterialConnectionService();
            _warehouseConnectionService = new WarehouseConnectionService();

            RequestMaterialSupplier = requestMaterialSupplier;

            InitializeComponent();

            LoadRequestMaterialSup();
            LoadWarehouses();
        }

        private void ButtonTransfer_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxWarehouse.SelectedItem != null)
            {
                var material = new Material
                {
                    Name = RequestMaterialSupplier.Name,
                    Type = RequestMaterialSupplier.Type,
                    Unit = RequestMaterialSupplier.Unit,
                    Count = RequestMaterialSupplier.Count,
                    WarehouseId = WarehouseNameToId(comboBoxWarehouse.SelectedItem.ToString())
                };

                _materialConnectionService.Add(material);

                IsSuccessful = true;

                Close();
            }
        }

        private void LoadRequestMaterialSup()
        {
            textBlockName.Text = RequestMaterialSupplier.Name;
            textBlockType.Text = RequestMaterialSupplier.Type.ToString();
            textBlockUnit.Text = RequestMaterialSupplier.Unit.ToString();
            textBlockCount.Text = RequestMaterialSupplier.Count.ToString();
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
