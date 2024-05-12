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

namespace Amkodor.EditWindows
{
    public partial class EditEmployeeWindow : Window
    {
        private readonly EmployeeConnectionService _employeeConnectionService;

        private Employee Employee { get; set; }

        public EditEmployeeWindow(EmployeeConnectionService employeeConnectionService, Employee employee)
        {
            _employeeConnectionService = employeeConnectionService;

            Employee = employee;

            InitializeComponent();

            LoadEmployee();
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (textBoxFullName.Text != string.Empty &&
                textBoxPhoneNumber.Text != string.Empty &&
                comboBoxPosition.SelectedItem != null)
            {
                Employee.FullName = textBoxFullName.Text.Trim();
                Employee.PhoneNumber = textBoxPhoneNumber.Text.Trim();
                Employee.Position = (PositionEnum)comboBoxPosition.SelectedItem;

                _employeeConnectionService.Edit(Employee);

                Close();
            }
        }

        private void LoadEmployee()
        {
            textBoxFullName.Text = Employee.FullName;
            textBoxPhoneNumber.Text = Employee.PhoneNumber;

            comboBoxPosition.ItemsSource = Enum.GetValues(typeof(PositionEnum));
            comboBoxPosition.SelectedItem = Employee.Position;
        }
    }
}
