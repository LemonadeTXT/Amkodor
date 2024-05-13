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
    public partial class EditMaterialSupplierWindow : Window
    {
        private readonly MaterialSupplierConnectionService _materialSupplierConnectionService;
        private readonly SupplierConnectionService _supplierConnectionService;

        private MaterialSupplier MaterialSupplier { get; set; }
        private IEnumerable<Supplier> Suppliers { get; set; }

        public EditMaterialSupplierWindow(MaterialSupplierConnectionService materialSupplierConnectionService, MaterialSupplier materialSupplier)
        {
            _materialSupplierConnectionService = materialSupplierConnectionService;

            _supplierConnectionService = new SupplierConnectionService();

            MaterialSupplier = materialSupplier;

            InitializeComponent();

            LoadMaterialSupplier();
            LoadSuppliers();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text != string.Empty &&
                comboBoxType.SelectedItem != null &&
                comboBoxUnit.SelectedItem != null &&
                decimal.TryParse(textBoxPriceForOne.Text, out _))
            {
                MaterialSupplier.Name = textBoxName.Text.Trim();
                MaterialSupplier.Type = (TypeEnum)comboBoxType.SelectedItem;
                MaterialSupplier.Unit = (UnitEnum)comboBoxUnit.SelectedItem;
                MaterialSupplier.PriceForOne = decimal.Parse(textBoxPriceForOne.Text.Trim());

                if (comboBoxSupplier.SelectedItem != null)
                {
                    MaterialSupplier.SupplierId = SupplierNameToId(comboBoxSupplier.SelectedItem.ToString());
                }

                _materialSupplierConnectionService.Edit(MaterialSupplier);

                Close();
            }
        }

        private void LoadMaterialSupplier()
        {
            textBoxName.Text = MaterialSupplier.Name;

            comboBoxType.ItemsSource = Enum.GetValues(typeof(TypeEnum));
            comboBoxType.SelectedItem = MaterialSupplier.Type;

            comboBoxUnit.ItemsSource = Enum.GetValues(typeof(UnitEnum));
            comboBoxUnit.SelectedItem = MaterialSupplier.Unit;

            textBoxPriceForOne.Text = MaterialSupplier.PriceForOne.ToString();
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
