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
    public partial class MaterialsPage : Page
    {
        private readonly MaterialConnectionService _materialConnectionService;

        public MaterialsPage()
        {
            _materialConnectionService = new MaterialConnectionService();

            InitializeComponent();

            LoadDatagrid();
        }

        private async Task LoadDatagrid()
        {
            dataGridMaterials.ItemsSource = await _materialConnectionService.GetAllMaterials();

            dataGridMaterials.Columns[0].Header = "№";
            dataGridMaterials.Columns[1].Header = "Название";
            dataGridMaterials.Columns[2].Header = "Тип";
            dataGridMaterials.Columns[3].Header = "Единица измерения";
        }
    }
}
