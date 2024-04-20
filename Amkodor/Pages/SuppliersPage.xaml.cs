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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Amkodor.Pages
{
    public partial class SuppliersPage : Page
    {
        private readonly SupplierConnectionService _supplierConnectionService;

        public SuppliersPage()
        {
            _supplierConnectionService = new SupplierConnectionService();

            InitializeComponent();

            LoadDatagrid();
        }

        private async Task LoadDatagrid()
        {
            dataGridSuppliers.ItemsSource = await _supplierConnectionService.GetAllSuppliers();

            dataGridSuppliers.Columns[0].Header = "№";
            dataGridSuppliers.Columns[1].Header = "Организация";
            dataGridSuppliers.Columns[2].Header = "Адрес";
            dataGridSuppliers.Columns[3].Header = "Почта";
            dataGridSuppliers.Columns[4].Header = "Контактный номер";
        }
    }
}
