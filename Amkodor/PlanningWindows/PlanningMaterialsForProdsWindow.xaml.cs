using Amkodor.AddWindows;
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

namespace Amkodor.PlanningWindows
{
    public partial class PlanningMaterialsForProdsWindow : Window
    {
        private readonly MaterialConnectionService _materialConnectionService;

        private readonly ProductInManufacturing _productInManufacturing;

        public PlanningMaterialsForProdsWindow(ProductInManufacturing productInManufacturing)
        {
            _materialConnectionService = new MaterialConnectionService();

            _productInManufacturing = productInManufacturing;

            InitializeComponent();

            LoadDataGrid();
        }

        private void ButtonAddMaterial_Click(object sender, RoutedEventArgs e)
        {
            var material = (Material)dataGridMaterials.SelectedItem;

            if (material != null)
            {
                new AddMaterialsForProdWindow(_materialConnectionService, material, _productInManufacturing).ShowDialog();
            }
        }

        private async void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            dataGridMaterials.ItemsSource = await _materialConnectionService.GetAllMaterials();
        }

        private async void TextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !string.IsNullOrEmpty(textBoxSearch.Text))
            {
                Search(textBoxSearch.Text);
            }
            else if (e.Key == Key.Enter && string.IsNullOrEmpty(textBoxSearch.Text))
            {
                dataGridMaterials.ItemsSource = await _materialConnectionService.GetAllMaterials();
            }
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            Search(textBoxSearch.Text);
        }

        private async void Search(string value)
        {
            if (textBoxSearch.Text != string.Empty)
            {
                dataGridMaterials.ItemsSource = await _materialConnectionService.Search(value);
            }
        }

        private async void LoadDataGrid()
        {
            dataGridMaterials.ItemsSource = await _materialConnectionService.GetAllMaterials();
        }
    }
}
