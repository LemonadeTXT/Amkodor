using Amkodor.AddWindows;
using Amkodor.Common.DTOs;
using Amkodor.ConnectionServices;
using Amkodor.InfoWindows;
using Amkodor.Models.Models;
using Amkodor.PlanningWindows;
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
    public partial class PlannedTasksPage : Page
    {
        private readonly ProductInManufConnectionService _productInManufConnectionService;

        public PlannedTasksPage()
        {
            _productInManufConnectionService = new ProductInManufConnectionService();

            InitializeComponent();

            LoadDataGrid();
        }

        private void ButtonAddPlannedProduct_Click(object sender, RoutedEventArgs e)
        {
            new AddPlannedProductWindow(_productInManufConnectionService).ShowDialog();
        }

        private async void ButtonMaterials_Click(object sender, RoutedEventArgs e)
        {
            var productInManufDto = (ProductInManufacturingDto)dataGridPlannedProduct.SelectedItem;

            if (productInManufDto != null)
            {
                var productInManuf = await _productInManufConnectionService.GetInactiveProdInManufById(productInManufDto.Id);

                new PlanningMaterialsForProdsWindow(productInManuf).ShowDialog();
            }
        }

        private async void ButtonEmployees_Click(object sender, RoutedEventArgs e)
        {
            var productInManufDto = (ProductInManufacturingDto)dataGridPlannedProduct.SelectedItem;

            if (productInManufDto != null)
            {
                var productInManuf = await _productInManufConnectionService.GetInactiveProdInManufById(productInManufDto.Id);

                new PlanningEmployeesForProdsWindow(_productInManufConnectionService, productInManuf).ShowDialog();
            }
        }

        private async void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            dataGridPlannedProduct.ItemsSource = ProdsInManufToDto(await _productInManufConnectionService.GetAllInactiveProductsInManufacturing());
        }

        private async void ButtonInfo_Click(object sender, RoutedEventArgs e)
        {
            var productInManufDto = (ProductInManufacturingDto)dataGridPlannedProduct.SelectedItem;

            if (productInManufDto != null)
            {
                var productInManuf = await _productInManufConnectionService.GetInactiveProdInManufById(productInManufDto.Id);

                new InfoProdInManufWindow(productInManuf).ShowDialog();
            }
        }

        private void ButtonSend_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void LoadDataGrid()
        {
            dataGridPlannedProduct.ItemsSource = ProdsInManufToDto(await _productInManufConnectionService.GetAllInactiveProductsInManufacturing());
        }

        private List<ProductInManufacturingDto> ProdsInManufToDto(IEnumerable<ProductInManufacturing> products)
        {
            var productsDto = new List<ProductInManufacturingDto>();

            foreach (var product in products)
            {
                productsDto.Add(new ProductInManufacturingDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Model = product.Model,
                    MaterialInManufacturingCount = product.MaterialInManufacturing.Count,
                    EmployeesCount = product.Employees.Count,
                });
            }

            return productsDto;
        }
    }
}
