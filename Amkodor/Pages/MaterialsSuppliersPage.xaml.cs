using Amkodor.AddWindows;
using Amkodor.ConnectionServices;
using Amkodor.EditWindows;
using Amkodor.Models.Models;
using Amkodor.RequestWindows;
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

        private void ButtonAddMaterialSupplier_Click(object sender, RoutedEventArgs e)
        {
            new AddMaterialSupplierWindow(_materialSupplierConnectionService).ShowDialog();
        }

        private void ButtonEditMaterialSupplier_Click(object sender, RoutedEventArgs e)
        {
            var materialSypplier = (MaterialSupplier)dataGridMaterialsSuppliers.SelectedItem;

            if (materialSypplier != null)
            {
                new EditMaterialSupplierWindow(_materialSupplierConnectionService, materialSypplier).ShowDialog();
            }
        }

        private void ButtonDeleteMaterialSupplier_Click(object sender, RoutedEventArgs e)
        {
            var materialSypplier = (MaterialSupplier)dataGridMaterialsSuppliers.SelectedItem;

            if (materialSypplier != null)
            {
                _materialSupplierConnectionService.Delete(materialSypplier);
            }
        }

        private async void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            dataGridMaterialsSuppliers.ItemsSource = await _materialSupplierConnectionService.GetAllMaterialsSuppliers();
        }

        private async void TextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !string.IsNullOrEmpty(textBoxSearch.Text))
            {
                Search(textBoxSearch.Text);
            }
            else if (e.Key == Key.Enter && string.IsNullOrEmpty(textBoxSearch.Text))
            {
                dataGridMaterialsSuppliers.ItemsSource = await _materialSupplierConnectionService.GetAllMaterialsSuppliers();
            }
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            Search(textBoxSearch.Text);
        }

        private void ButtonRequest_Click(object sender, RoutedEventArgs e)
        {
            var materialSypplier = (MaterialSupplier)dataGridMaterialsSuppliers.SelectedItem;

            if (materialSypplier != null)
            {
                new RequestMaterialSupplierWindow(materialSypplier).ShowDialog();
            }
        }

        private async void Search(string value)
        {
            if (textBoxSearch.Text != string.Empty)
            {
                dataGridMaterialsSuppliers.ItemsSource = await _materialSupplierConnectionService.Search(value);
            }
        }

        private async void LoadDatagrid()
        {
            dataGridMaterialsSuppliers.ItemsSource = await _materialSupplierConnectionService.GetAllMaterialsSuppliers();
        }
    }
}
