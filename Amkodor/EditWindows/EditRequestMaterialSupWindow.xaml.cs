using Amkodor.Common.Enums;
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

namespace Amkodor.EditWindows
{
    public partial class EditRequestMaterialSupWindow : Window
    {
        private readonly RequestMaterialSupConnectionService _requestMaterialSupConnectionService;

        private RequestMaterialSupplier RequestMaterialSupplier { get; set; }

        public EditRequestMaterialSupWindow(RequestMaterialSupConnectionService requestMaterialSupConnectionService,
            RequestMaterialSupplier requestMaterialSupplier)
        {
            _requestMaterialSupConnectionService = requestMaterialSupConnectionService;

            RequestMaterialSupplier = requestMaterialSupplier;

            InitializeComponent();

            LoadRequestMaterialSup();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text != string.Empty && 
                comboBoxType.SelectedItem != null &&
                comboBoxUnit.SelectedItem != null && 
                decimal.TryParse(textBoxPriceForOne.Text, out _) && 
                int.TryParse(textBoxCount.Text, out _) && 
                datePickerArrivalDate.Text != string.Empty)
            {
                RequestMaterialSupplier.Name = textBoxName.Text;
                RequestMaterialSupplier.Type = (TypeEnum)comboBoxType.SelectedItem;
                RequestMaterialSupplier.Unit = (UnitEnum)comboBoxUnit.SelectedItem;
                RequestMaterialSupplier.PriceForOne = decimal.Parse(textBoxPriceForOne.Text);
                RequestMaterialSupplier.Count = int.Parse(textBoxCount.Text);
                RequestMaterialSupplier.ArrivalDate = datePickerArrivalDate.DisplayDate;

                _requestMaterialSupConnectionService.Edit(RequestMaterialSupplier);

                Close();
            }
        }

        private void LoadRequestMaterialSup()
        {
            textBoxName.Text = RequestMaterialSupplier.Name;

            comboBoxType.ItemsSource = Enum.GetValues(typeof(TypeEnum));
            comboBoxType.SelectedItem = RequestMaterialSupplier.Type;

            comboBoxUnit.ItemsSource = Enum.GetValues(typeof(UnitEnum));
            comboBoxUnit.SelectedItem = RequestMaterialSupplier.Unit;

            textBoxPriceForOne.Text = RequestMaterialSupplier.PriceForOne.ToString();
            textBoxCount.Text = RequestMaterialSupplier.Count.ToString();
            datePickerArrivalDate.Text = RequestMaterialSupplier.ArrivalDate.ToString();
        }
    }
}
