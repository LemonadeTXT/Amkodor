using Amkodor.ConnectionServices;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Amkodor.Pages
{
    public partial class MaterialsSuppliersPage : Page
    {
        private readonly MaterialSupplierConnectionService _materialSupplierConnectionService;

        public MaterialsSuppliersPage()
        {
            _materialSupplierConnectionService = new MaterialSupplierConnectionService();

            InitializeComponent();

            LoadDatagrid();
        }

        private async Task LoadDatagrid()
        {
            dataGridMaterialsSuppliers.ItemsSource = await _materialSupplierConnectionService.GetAllMaterialsSuppliers();

            dataGridMaterialsSuppliers.Columns[0].Header = "№";
            dataGridMaterialsSuppliers.Columns[1].Header = "Название";
            dataGridMaterialsSuppliers.Columns[2].Header = "Тип";
            dataGridMaterialsSuppliers.Columns[3].Header = "Единица измерения";
            dataGridMaterialsSuppliers.Columns[4].Header = "Цена";
        }
    }
}
