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

namespace Amkodor.TransferWindows
{
    public partial class TransferProdInManufWindow : Window
    {
        private readonly ProductConnectionService _productConnectionService;
        private readonly ProductInManufConnectionService _productInManufConnectionService;

        private ProductInManufacturing ProductInManufacturing { get; set; }

        public bool IsSuccessful { get; set; }

        public TransferProdInManufWindow(ProductInManufConnectionService productInManufConnectionService, ProductInManufacturing productInManufacturing)
        {
            _productConnectionService = new ProductConnectionService();

            _productInManufConnectionService = productInManufConnectionService;

            ProductInManufacturing = productInManufacturing;

            InitializeComponent();

            LoadProdInManuf();
        }

        private void ButtonTransfer_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.TryParse(textBoxCostPrice.Text, out _))
            {
                var product = new Product()
                {
                    Name = ProductInManufacturing.Name,
                    Model = ProductInManufacturing.Model,
                    CostPrice = decimal.Parse(textBoxCostPrice.Text),
                    BuildDate = (DateTime)ProductInManufacturing.DeadLine,
                };

                _productConnectionService.Add(product);

                IsSuccessful = true;

                Close();
            }
        }

        private void LoadProdInManuf()
        {
            textBlockName.Text = ProductInManufacturing.Name;
            textBlockModel.Text = ProductInManufacturing.Model;
            textBlockReadiness.Text = ProductInManufacturing.Readiness;
            textBlockDeadLine.Text = ProductInManufacturing.DeadLine.ToString();
        }
    }
}
