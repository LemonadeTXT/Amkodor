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

namespace Amkodor.InfoWindows
{
    public partial class InfoProdInManufWindow : Window
    {
        private readonly ProductInManufacturing _productInManufacturing;

        public InfoProdInManufWindow(ProductInManufacturing productInManufacturing)
        {
            _productInManufacturing = productInManufacturing;

            InitializeComponent();

            LoadDataGrids();
        }

        private void LoadDataGrids()
        {
            dataGridMaterialsInManuf.ItemsSource = _productInManufacturing.MaterialInManufacturing;
            dataGridEmployeesInManuf.ItemsSource = _productInManufacturing.Employees;
        }
    }
}
