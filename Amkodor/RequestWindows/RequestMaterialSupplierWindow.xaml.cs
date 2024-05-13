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

namespace Amkodor.RequestWindows
{
    public partial class RequestMaterialSupplierWindow : Window
    {
        private readonly RequestMaterialSupConnectionService _requestMaterialSupConnectionService;

        private readonly MaterialSupplier _materialSupplier;

        public RequestMaterialSupplierWindow(MaterialSupplier materialSupplier)
        {
            _requestMaterialSupConnectionService = new RequestMaterialSupConnectionService();

            _materialSupplier = materialSupplier;

            InitializeComponent();

            LoadRequest(materialSupplier);
        }

        private void ButtonRequest_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(textBoxCount.Text, out _))
            {
                var requestMaterialSup = new RequestMaterialSupplier
                {
                    Name = _materialSupplier.Name,
                    Type = _materialSupplier.Type,
                    Unit = _materialSupplier.Unit,
                    PriceForOne = _materialSupplier.PriceForOne,
                    Count = int.Parse(textBoxCount.Text.Trim()),
                    Approve = false,
                    SupplierId = _materialSupplier.SupplierId,
                };

                _requestMaterialSupConnectionService.Add(requestMaterialSup);

                Close();
            }
        }

        private void LoadRequest(MaterialSupplier materialSupplier)
        {
            textBlockName.Text = materialSupplier.Name;
            textBlockPrice.Text = materialSupplier.PriceForOne.ToString();
        }
    }
}
