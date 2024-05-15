using Amkodor.AddWindows;
using Amkodor.ConnectionServices;
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
using System.Windows.Shapes;

namespace Amkodor.PlanningWindows
{
    public partial class PlanningEmployeesForProdsWindow : Window
    {
        private readonly EmployeeConnectionService _employeeConnectionService;
        private readonly ProductInManufConnectionService _productInManufConnectionService;
        private readonly ProductInManufacturing _productInManufacturing;

        public PlanningEmployeesForProdsWindow(ProductInManufConnectionService productInManufConnectionService, ProductInManufacturing productInManufacturing)
        {
            _employeeConnectionService = new EmployeeConnectionService();

            _productInManufConnectionService = productInManufConnectionService;
            _productInManufacturing = productInManufacturing;

            InitializeComponent();

            LoadDataGrid();
        }

        private void ButtonAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            var employee = (Employee)dataGridEmployees.SelectedItem;

            if (employee != null)
            {
                _productInManufacturing.Employees.Add(employee);

                _productInManufConnectionService.Edit(_productInManufacturing);

                LoadDataGrid();
            }
        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadDataGrid();
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

        private async void LoadDataGrid()
        {
            var freeEmployees = new List<Employee>();

            var employees = await _employeeConnectionService.GetAllEmployees();

            foreach (var employee in employees)
            {
                var isFree = true;

                foreach (var productInManuf in employee.ProductsInManufacturing)
                {
                    if (productInManuf.Id == _productInManufacturing.Id)
                    {
                        isFree = false; 
                        break;
                    }
                }

                if (isFree)
                {
                    freeEmployees.Add(employee);
                }
            }

            dataGridEmployees.ItemsSource = freeEmployees;
        }
    }
}
