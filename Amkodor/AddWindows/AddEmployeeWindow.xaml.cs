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
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Amkodor.AddWindows
{
    public partial class AddEmployeeWindow : Window
    {
        private readonly EmployeeConnectionService _employeeConnectionService;

        public AddEmployeeWindow(EmployeeConnectionService employeeConnectionService)
        {
            _employeeConnectionService = employeeConnectionService;

            InitializeComponent();

            LoadComboBoxes();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxFullName.Text != string.Empty &&
                textBoxPhoneNumber.Text != string.Empty &&
                comboBoxPosition.SelectedItem != null)
            {
                var employee = new Employee
                {
                    FullName = textBoxFullName.Text.Trim(),
                    PhoneNumber = textBoxPhoneNumber.Text.Trim(),
                    Position = (PositionEnum)comboBoxPosition.SelectedItem,
                };

                _employeeConnectionService.Add(employee);

                Close();
            }
        }

        private void LoadComboBoxes()
        {
            comboBoxPosition.ItemsSource = Enum.GetValues(typeof(PositionEnum));
        }
    }
}
