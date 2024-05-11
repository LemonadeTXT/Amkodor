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
    public partial class EditSupplierWindow : Window
    {
        private readonly SupplierConnectionService _supplierConnectionService;

        private Supplier Supplier { get; set; }

        public EditSupplierWindow(SupplierConnectionService supplierConnectionService, Supplier supplier)
        {
            _supplierConnectionService = supplierConnectionService;

            Supplier = supplier;

            InitializeComponent();

            LoadSupplier();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text != string.Empty &&
                textBoxAddress.Text != string.Empty &&
                textBoxEmail.Text != string.Empty &&
                textBoxContactNumber.Text != string.Empty)
            {
                Supplier.Name = textBoxName.Text.Trim();
                Supplier.Address = textBoxAddress.Text.Trim();
                Supplier.Email = textBoxEmail.Text.Trim();
                Supplier.ContactNumber = textBoxContactNumber.Text.Trim();

                _supplierConnectionService.Edit(Supplier);

                Close();
            }
        }

        private void LoadSupplier()
        {
            textBoxName.Text = Supplier.Name;
            textBoxAddress.Text = Supplier.Address;
            textBoxEmail.Text = Supplier.Email;
            textBoxContactNumber.Text = Supplier.ContactNumber;
        }
    }
}
