using Amkodor.ApproveWindows;
using Amkodor.ConnectionServices;
using Amkodor.EditWindows;
using Amkodor.Models.Models;
using Amkodor.TransferWindows;
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

        private async void LoadDatagrid()
        {
            dataGridRequestMaterialsSuppliers.ItemsSource = await _requestMaterialSupConnectionService.GetAllRequestMaterialsSups();
        }
    }
}
