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

namespace Amkodor.ApproveWindows
{
    public partial class ApproveRequestMatsSupsWindow : Window
    {
        private readonly RequestMaterialSupConnectionService _requestMaterialSupConnectionService;

        private RequestMaterialSupplier RequestMaterialSupplier { get; set; }

        public ApproveRequestMatsSupsWindow(RequestMaterialSupConnectionService requestMaterialSupConnectionService, 
            RequestMaterialSupplier requestMaterialSupplier)
        {
            _requestMaterialSupConnectionService = requestMaterialSupConnectionService;

            RequestMaterialSupplier = requestMaterialSupplier;

            InitializeComponent();

            LoadRequestMaterialSup();
        }

        private void ButtonApprove_Click(object sender, RoutedEventArgs e)
        {
            if (datePickerArrivalDate.Text != string.Empty)
            {
                RequestMaterialSupplier.ArrivalDate = datePickerArrivalDate.DisplayDate;
                RequestMaterialSupplier.Approve = true;

                _requestMaterialSupConnectionService.Edit(RequestMaterialSupplier);

                Close();
            }
        }

        private void LoadRequestMaterialSup()
        {
            textBlockName.Text = RequestMaterialSupplier.Name;
            textBlockPriceForOne.Text = RequestMaterialSupplier.PriceForOne.ToString();
            textBlockCount.Text = RequestMaterialSupplier.Count.ToString();
        }
    }
}
