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
    public partial class EditMaterialWindow : Window
    {
        private readonly MaterialConnectionService _materialConnectionService;

        private Material Material { get; set; }

        public EditMaterialWindow(MaterialConnectionService materialConnectionService, Material material)
        {
            _materialConnectionService = materialConnectionService;

            Material = material;

            InitializeComponent();

            LoadComboBoxes();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxName.Text != string.Empty && 
                comboBoxType.SelectedItem != null && 
                comboBoxUnit.SelectedItem != null)
            {
                Material.Name = textBoxName.Text.Trim();
                Material.Type = (TypeEnum)comboBoxType.SelectedItem;
                Material.Unit = (UnitEnum)comboBoxUnit.SelectedItem;

                _materialConnectionService.Edit(Material);

                Close();
            }
        }

        private void LoadComboBoxes()
        {
            comboBoxType.ItemsSource = Enum.GetValues(typeof(TypeEnum));
            comboBoxType.SelectedItem = Material.Type;

            comboBoxUnit.ItemsSource = Enum.GetValues(typeof(UnitEnum));
            comboBoxUnit.SelectedItem = Material.Unit;
        }
    }
}
