﻿using Amkodor.ApproveWindows;
using Amkodor.Common.DTOs;
using Amkodor.ConnectionServices;
using Amkodor.EditWindows;
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
    public partial class RequestMaterialSupplierPage : Page
    {
        private readonly RequestMaterialSupConnectionService _requestMaterialSupConnectionService;

        public RequestMaterialSupplierPage()
        {
            _requestMaterialSupConnectionService = new RequestMaterialSupConnectionService();

            InitializeComponent();

            LoadDatagrid();
        }

        private void ButtonEditRequestMatSup_Click(object sender, RoutedEventArgs e)
        {
            var requestMaterialSyp = (RequestMaterialSupplier)dataGridRequestMaterialsSuppliers.SelectedItem;

            if (requestMaterialSyp != null)
            {
                new EditRequestMaterialSupWindow(_requestMaterialSupConnectionService, requestMaterialSyp).ShowDialog();
            }
        }

        private void ButtonDeleteRequestMatSup_Click(object sender, RoutedEventArgs e)
        {
            var requestMaterialSyp = (RequestMaterialSupplier)dataGridRequestMaterialsSuppliers.SelectedItem;

            if (requestMaterialSyp != null)
            {
                _requestMaterialSupConnectionService.Delete(requestMaterialSyp);
            }
        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private async void TextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !string.IsNullOrEmpty(textBoxSearch.Text))
            {
                Search(textBoxSearch.Text);
            }
            else if (e.Key == Key.Enter && string.IsNullOrEmpty(textBoxSearch.Text))
            {
                dataGridRequestMaterialsSuppliers.ItemsSource = await _requestMaterialSupConnectionService.GetAllRequestMaterialsSups();
            }
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            Search(textBoxSearch.Text);
        }

        private void ButtonTransfer_Click(object sender, RoutedEventArgs e)
        {
            var requestMaterialSyp = (RequestMaterialSupplier)dataGridRequestMaterialsSuppliers.SelectedItem;

            if (requestMaterialSyp != null && 
                requestMaterialSyp.ArrivalDate != null && 
                requestMaterialSyp.Approve == true)
            {
                var transfer = new TransferRequestMatSupWindow(requestMaterialSyp);
                transfer.ShowDialog();

                if (transfer.IsSuccessful)
                {
                    _requestMaterialSupConnectionService.Delete(requestMaterialSyp);

                    Refresh();
                }
            }
        }

        private void ButtonApprove_Click(object sender, RoutedEventArgs e)
        {
            var requestMaterialSyp = (RequestMaterialSupplier)dataGridRequestMaterialsSuppliers.SelectedItem;

            if (requestMaterialSyp != null)
            {
                new ApproveRequestMatsSupsWindow(_requestMaterialSupConnectionService, requestMaterialSyp).ShowDialog();
            }
        }

        private void ButtonExcel_Click(object sender, RoutedEventArgs e)
        {
            using var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Запрашиваемые материалы");
            ws.Cell(1, 1).InsertTable((IEnumerable<RequestMaterialSupplier>)dataGridRequestMaterialsSuppliers.ItemsSource);
            ws.Cell("A" + 1).Value = "№";
            ws.Cell("B" + 1).Value = "Название";
            ws.Cell("C" + 1).Value = "Тип";
            ws.Cell("D" + 1).Value = "Ед. измерения";
            ws.Cell("E" + 1).Value = "Цена за штуку";
            ws.Cell("F" + 1).Value = "Количество";
            ws.Cell("G" + 1).Value = "Дата прибытия";
            ws.Cell("H" + 1).Value = "Статус";
            ws.Cell("I" + 1).Value = "№ Поставщика";
            wb.SaveAs(@"C:\Users\lemon\Desktop\Запрашиваемые материалы.xlsx");

            MessageBox.Show("Данные добавлены в файл \'Запрашиваемые материалы.xlsx\'");
        }

        private void ButtonWord_Click(object sender, RoutedEventArgs e)
        {
            EquipmentToWord(@"C:\Users\lemon\Desktop\Запрашиваемые материалы.docx",
                        (List<RequestMaterialSupplier>)dataGridRequestMaterialsSuppliers.ItemsSource);

            MessageBox.Show("Данные добавлены в файл \'Запрашиваемые материалы.docx\'");
        }

        private async void Refresh()
        {
            dataGridRequestMaterialsSuppliers.ItemsSource = await _requestMaterialSupConnectionService.GetAllRequestMaterialsSups();
        }

        private async void Search(string value)
        {
            if (textBoxSearch.Text != string.Empty)
            {
                dataGridRequestMaterialsSuppliers.ItemsSource = await _requestMaterialSupConnectionService.Search(value);
            }
        }

        private void EquipmentToWord(string filePath, List<RequestMaterialSupplier> requestMaterialsSuppliers)
        {
            using var document = WordDocument.Create(filePath);

            foreach (var requestMaterialSup in requestMaterialsSuppliers)
            {
                var prodDto =
                    $"№: {requestMaterialSup.Id}\n" +
                    $"Название: {requestMaterialSup.Name}\n" +
                    $"Тип: {requestMaterialSup.Type}\n" +
                    $"Ед. измерения: {requestMaterialSup.Unit}\n" +
                    $"Цена за штуку: {requestMaterialSup.PriceForOne}\n" +
                    $"Количество: {requestMaterialSup.Count}\n" +
                    $"Дата прибытия: {requestMaterialSup.ArrivalDate}\n" +
                    $"Статус: {requestMaterialSup.Approve}\n" +
                    $"№ Поставщика: {requestMaterialSup.SupplierId}\n";

                document.AddParagraph(prodDto);
            }

            document.Save();
        }

        private async void LoadDatagrid()
        {
            dataGridRequestMaterialsSuppliers.ItemsSource = await _requestMaterialSupConnectionService.GetAllRequestMaterialsSups();
        }
    }
}
