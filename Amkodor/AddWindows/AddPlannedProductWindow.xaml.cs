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
    public partial class AddPlannedProductWindow : Window
    {
        private readonly ProductInManufConnectionService _productInManufConnectionService;

        public AddPlannedProductWindow(ProductInManufConnectionService productInManufConnectionService)
        {
            _productInManufConnectionService = productInManufConnectionService;

            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text != string.Empty && 
                textBoxModel.Text != string.Empty)
            {
                var prodInManuf = new ProductInManufacturing
                {
                    Name = textBoxName.Text.Trim(),
                    Model = textBoxModel.Text.Trim(),
                    InManufacturing = false,
                };

                _productInManufConnectionService.Add(prodInManuf);

                Close();
            }
        }
    }
}
