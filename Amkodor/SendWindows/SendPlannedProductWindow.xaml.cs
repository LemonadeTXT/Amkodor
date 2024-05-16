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

namespace Amkodor.SendWindows
{
    public partial class SendPlannedProductWindow : Window
    {
        private readonly ProductInManufConnectionService _productInManufConnectionService;

        private ProductInManufacturing ProductInManufacturing { get; set; }

        public bool IsSuccessful { get; set; }

        public SendPlannedProductWindow(ProductInManufConnectionService productInManufConnectionService, ProductInManufacturing productInManufacturing)
        {
            _productInManufConnectionService = productInManufConnectionService;

            ProductInManufacturing = productInManufacturing;

            InitializeComponent();

            LoadProductInManuf();
        }

        private void ButtonSend_Click(object sender, RoutedEventArgs e)
        {
            if (datePickerDeadLine.Text != string.Empty)
            {
                ProductInManufacturing.Readiness = "0%";
                ProductInManufacturing.DeadLine = datePickerDeadLine.DisplayDate;
                ProductInManufacturing.InManufacturing = true;

                _productInManufConnectionService.EditTarget(ProductInManufacturing);

                IsSuccessful = true;

                Close();
            }
        }

        private void LoadProductInManuf()
        {
            textBlockName.Text = ProductInManufacturing.Name;
            textBlockModel.Text = ProductInManufacturing.Model;
        }
    }
}
