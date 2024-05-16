using Amkodor.Common.DTOs;
using Amkodor.ConnectionServices;
using Amkodor.EditWindows;
using Amkodor.InfoWindows;
using Amkodor.Models.Models;
using Amkodor.TransferWindows;
using ClosedXML.Excel;
using OfficeIMO.Word;
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
    public partial class ProductsInManufPage : Page
    {
        private readonly ProductInManufConnectionService _productInManufConnectionService;

        public ProductsInManufPage()
        {
            _productInManufConnectionService = new ProductInManufConnectionService();

            InitializeComponent();

            LoadDataGrid();
        }

        private async void ButtonEditProdsInManuf_Click(object sender, RoutedEventArgs e)
        {
            var productInManufDto = (ProductInManufacturingDto)dataGridProductsInManuf.SelectedItem;

            if (productInManufDto != null)
            {
                var productInManuf = await _productInManufConnectionService.GetActiveProdInManufById(productInManufDto.Id);

                new EditProdInManufWindow(_productInManufConnectionService, productInManuf).ShowDialog();
            }
        }

        private async void ButtonDeleteProdsInManuf_Click(object sender, RoutedEventArgs e)
        {
            var productInManufDto = (ProductInManufacturingDto)dataGridProductsInManuf.SelectedItem;

            if (productInManufDto != null)
            {
                var productInManuf = await _productInManufConnectionService.GetActiveProdInManufById(productInManufDto.Id);

                _productInManufConnectionService.Delete(productInManuf);
            }
        }

        private async void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private async void ButtonInfo_Click(object sender, RoutedEventArgs e)
        {
            var productInManufDto = (ProductInManufacturingDto)dataGridProductsInManuf.SelectedItem;

            if (productInManufDto != null)
            {
                var productInManuf = await _productInManufConnectionService.GetActiveProdInManufById(productInManufDto.Id);

                new InfoProdInManufWindow(productInManuf).ShowDialog();
            }
        }

        private void ButtonExcel_Click(object sender, RoutedEventArgs e)
        {
            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Изделия в производстве");
            ws.Cell(1, 1).InsertTable((IEnumerable<ProductInManufacturingDto>)dataGridProductsInManuf.ItemsSource);
            ws.Cell("A" + 1).Value = "№";
            ws.Cell("B" + 1).Value = "Название";
            ws.Cell("C" + 1).Value = "Модель";
            ws.Cell("D" + 1).Value = "Готовность";
            ws.Cell("E" + 1).Value = "Срок сдачи";
            ws.Cell("F" + 1).Value = "Виды материалов";
            ws.Cell("G" + 1).Value = "Колич. сотрудников";
            wb.SaveAs(@"C:\Users\lemon\Desktop\Изделия в производстве.xlsx");

            MessageBox.Show("Данные добавлены в файл \'Изделия в производстве.xlsx\'");
        }

        private void ButtonWord_Click(object sender, RoutedEventArgs e)
        {
            EquipmentToWord(@"C:\Users\lemon\Desktop\Изделия в производстве.docx",
                        (List<ProductInManufacturingDto>)dataGridProductsInManuf.ItemsSource);

            MessageBox.Show("Данные добавлены в файл \'Изделия в производстве.docx\'");
        }

        private async void ButtonTransfer_Click(object sender, RoutedEventArgs e)
        {
            var productInManufDto = (ProductInManufacturingDto)dataGridProductsInManuf.SelectedItem;

            if (productInManufDto != null)
            {
                var productInManuf = await _productInManufConnectionService.GetActiveProdInManufById(productInManufDto.Id);

                var transfer = new TransferProdInManufWindow(_productInManufConnectionService, productInManuf);
                transfer.ShowDialog();

                if (transfer.IsSuccessful)
                {
                    _productInManufConnectionService.Delete(productInManuf);

                    Refresh();
                }
            }
        }

        private async void Refresh()
        {
            dataGridProductsInManuf.ItemsSource = ProdsInManufToDto(await _productInManufConnectionService.GetAllActiveProductsInManufacturing());
        }

        private void EquipmentToWord(string filePath, List<ProductInManufacturingDto> productsInManufDto)
        {
            using var document = WordDocument.Create(filePath);

            foreach (var productDto in productsInManufDto)
            {
                var prodDto = 
                    $"№: {productDto.Id}\n" +
                    $"Название: {productDto.Name}\n" +
                    $"Модель: {productDto.Model}\n" +
                    $"Готовность: {productDto.Readiness}\n" +
                    $"Срок сдачи: {productDto.DeadLine}\n" +
                    $"Виды материалов: {productDto.MaterialInManufacturingCount}\n" +
                    $"Колич. сотрудников: {productDto.EmployeesCount}\n";

                document.AddParagraph(prodDto);
            }

            document.Save();
        }

        private async void LoadDataGrid()
        {
            dataGridProductsInManuf.ItemsSource = ProdsInManufToDto(await _productInManufConnectionService.GetAllActiveProductsInManufacturing());
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
                    Readiness = product.Readiness,
                    DeadLine = product.DeadLine,
                    MaterialInManufacturingCount = product.MaterialInManufacturing.Count,
                    EmployeesCount = product.Employees.Count,
                });
            }

            return productsDto;
        }
    }
}
