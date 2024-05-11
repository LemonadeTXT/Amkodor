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

namespace Amkodor.AddWindows
{
    public partial class AddMaterialWindow : Window
    {
        private readonly MaterialConnectionService _materialConnectionService;

        public AddMaterialWindow(MaterialConnectionService materialConnectionService)
        {
            _materialConnectionService = materialConnectionService;

            InitializeComponent();

            LoadComboBoxes();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text != string.Empty &&
                comboBoxType.SelectedItem != null &&
                comboBoxUnit.SelectedItem != null)
            {
                var material = new Material
                {
                    Name = textBoxName.Text.Trim(),
                    Type = (TypeEnum)comboBoxType.SelectedItem,
                    Unit = (UnitEnum)comboBoxUnit.SelectedItem,
                };

                _materialConnectionService.Add(material);

                Close();
            }
        }

        private void LoadComboBoxes()
        {
            comboBoxType.ItemsSource = Enum.GetValues(typeof(TypeEnum));
            comboBoxUnit.ItemsSource = Enum.GetValues(typeof(UnitEnum));
        }
    }
}
