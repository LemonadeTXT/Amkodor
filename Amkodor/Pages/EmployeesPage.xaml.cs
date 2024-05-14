using Amkodor.AddWindows;
using Amkodor.ConnectionServices;
using Amkodor.EditWindows;
using Amkodor.InfoWindows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Amkodor.Pages
{
    public partial class EmployeesPage : Page
    {
        private readonly EmployeeConnectionService _employeeConnectionService;

        public EmployeesPage()
        {
            _employeeConnectionService = new EmployeeConnectionService();

            InitializeComponent();

            LoadDatagrid();
        }

        private void ButtonAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            new AddEmployeeWindow(_employeeConnectionService).ShowDialog();
        }

        private void ButtonEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            var employee = (Employee)dataGridEmployees.SelectedItem;

            if (employee != null)
            {
                new EditEmployeeWindow(_employeeConnectionService, employee).ShowDialog();
            }
        }

        private void ButtonDeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            var employee = (Employee)dataGridEmployees.SelectedItem;

            if (employee != null)
            {
                _employeeConnectionService.Delete(employee);
            }
        }

        private async void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            dataGridEmployees.ItemsSource = await _employeeConnectionService.GetAllEmployees();
        }

        private async void TextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !string.IsNullOrEmpty(textBoxSearch.Text))
            {
                Search(textBoxSearch.Text);
            }
            else if (e.Key == Key.Enter && string.IsNullOrEmpty(textBoxSearch.Text))
            {
                dataGridEmployees.ItemsSource = await _employeeConnectionService.GetAllEmployees();
            }
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            Search(textBoxSearch.Text);
        }

        private void ButtonInfo_Click(object sender, RoutedEventArgs e)
        {
            var employee = (Employee)dataGridEmployees.SelectedItem;

            if (employee != null)
            {
                new InfoEmployeeWindow(employee).ShowDialog();
            }
        }

        private async void Search(string value)
        {
            if (textBoxSearch.Text != string.Empty)
            {
                dataGridEmployees.ItemsSource = await _employeeConnectionService.Search(value);
            }
        }

        private async void LoadDatagrid()
        {
            dataGridEmployees.ItemsSource = await _employeeConnectionService.GetAllEmployees();
        }
    }
}
