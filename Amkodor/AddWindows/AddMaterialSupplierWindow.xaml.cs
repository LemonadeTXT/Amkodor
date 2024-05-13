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
    public partial class AddMaterialSupplierWindow : Window
    {
        private readonly MaterialSupplierConnectionService _materialSupplierConnectionService;
        private readonly SupplierConnectionService _supplierConnectionService;

        private IEnumerable<Supplier> Suppliers { get; set; }

        public AddMaterialSupplierWindow(MaterialSupplierConnectionService materialSupplierConnectionService)
        {
            _materialSupplierConnectionService = materialSupplierConnectionService;

            _supplierConnectionService = new SupplierConnectionService();

            InitializeComponent();

            LoadComboBoxes();
            LoadSuppliers();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text != string.Empty &&
                comboBoxType.SelectedItem != null &&
                comboBoxUnit.SelectedItem != null &&
                decimal.TryParse(textBoxPriceForOne.Text, out _) &&
                comboBoxSupplier.SelectedItem != null)
            {
                var materialSupplier = new MaterialSupplier
                {
                    Name = textBoxName.Text.Trim(),
                    Type = (TypeEnum)comboBoxType.SelectedItem,
                    Unit = (UnitEnum)comboBoxUnit.SelectedItem,
                    PriceForOne = decimal.Parse(textBoxPriceForOne.Text.Trim()),
                    SupplierId = SupplierNameToId(comboBoxSupplier.SelectedItem.ToString()),
                };

                _materialSupplierConnectionService.Add(materialSupplier);

                Close();
            }
        }

        private void LoadComboBoxes()
        {
            comboBoxType.ItemsSource = Enum.GetValues(typeof(TypeEnum));
            comboBoxUnit.ItemsSource = Enum.GetValues(typeof(UnitEnum));
        }

        private async void LoadSuppliers()
        {
            Suppliers = await _supplierConnectionService.GetAllSuppliers();

            var suppliersNames = new List<string>();

            foreach (var supplier in Suppliers)
            {
                suppliersNames.Add(supplier.Name);
            }

            comboBoxSupplier.ItemsSource = suppliersNames;
        }

        private int SupplierNameToId(string supplierName)
        {
            foreach (var supplier in Suppliers)
            {
                if (supplier.Name == supplierName)
                {
                    return supplier.Id;
                }
            }

            return 0;
        }
    }
}
