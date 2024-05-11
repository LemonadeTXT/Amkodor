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
    public partial class AddSupplierWindow : Window
    {
        private readonly SupplierConnectionService _supplierConnectionService;

        public AddSupplierWindow(SupplierConnectionService supplierConnectionService)
        {
            _supplierConnectionService = supplierConnectionService;

            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text != string.Empty &&
                textBoxAddress.Text != string.Empty &&
                textBoxEmail.Text != string.Empty &&
                textBoxContactNumber.Text != string.Empty)
            {
                var supplier = new Supplier
                {
                    Name = textBoxName.Text.Trim(),
                    Address = textBoxAddress.Text.Trim(),
                    Email = textBoxEmail.Text.Trim(),
                    ContactNumber = textBoxContactNumber.Text.Trim(),
                };

                _supplierConnectionService.Add(supplier);

                Close();
            }
        }
    }
}
