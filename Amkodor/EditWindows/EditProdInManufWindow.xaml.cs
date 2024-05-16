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
    public partial class EditProdInManufWindow : Window
    {
        private readonly ProductInManufConnectionService _productInManufConnectionService;

        private ProductInManufacturing ProductInManufacturing { get; set; }

        public EditProdInManufWindow(ProductInManufConnectionService productInManufConnectionService, ProductInManufacturing productInManufacturing)
        {
            _productInManufConnectionService = productInManufConnectionService;

            ProductInManufacturing = productInManufacturing;

            InitializeComponent();

            LoadProdInManuf();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text != string.Empty &&
                textBoxModel.Text != string.Empty &&
                textBoxReadiness.Text != string.Empty &&
                datePickerDeadLine.Text != string.Empty)
            {
                ProductInManufacturing.Name = textBoxName.Text.Trim();
                ProductInManufacturing.Model = textBoxModel.Text.Trim();
                ProductInManufacturing.Readiness = textBoxReadiness.Text.Trim();
                ProductInManufacturing.DeadLine = datePickerDeadLine.DisplayDate;

                _productInManufConnectionService.EditTarget(ProductInManufacturing);

                Close();
            }
        }

        private void LoadProdInManuf()
        {
            textBoxName.Text = ProductInManufacturing.Name;
            textBoxModel.Text = ProductInManufacturing.Model;
            textBoxReadiness.Text = ProductInManufacturing.Readiness;
            datePickerDeadLine.Text = ProductInManufacturing.DeadLine.ToString();
        }
    }
}
