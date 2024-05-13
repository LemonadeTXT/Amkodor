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

namespace Amkodor.EditWindows
{
    public partial class EditProductWindow : Window
    {
        private readonly ProductConnectionService _productConnectionService;

        private Product Product { get; set; }

        public EditProductWindow(ProductConnectionService productConnectionService, Product product)
        {
            _productConnectionService = productConnectionService;

            Product = product;

            InitializeComponent();

            LoadProduct();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text != string.Empty &&
                textBoxModel.Text != string.Empty &&
                decimal.TryParse(textBoxCostPrice.Text, out _) &&
                datePickerBuildingDate.Text != string.Empty)
            {
                Product.Name = textBoxName.Text.Trim();
                Product.Model = textBoxModel.Text.Trim();
                Product.CostPrice = decimal.Parse(textBoxCostPrice.Text.Trim());
                Product.BuildDate = datePickerBuildingDate.DisplayDate;

                _productConnectionService.Edit(Product);

                Close();
            }
        }

        private void LoadProduct()
        {
            textBoxName.Text = Product.Name;
            textBoxModel.Text = Product.Model;
            textBoxCostPrice.Text = Product.CostPrice.ToString();
            datePickerBuildingDate.Text = Product.BuildDate.ToString();
        }
    }
}
