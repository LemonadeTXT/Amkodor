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

namespace Amkodor.InfoWindows
{
    public partial class InfoEmployeeWindow : Window
    {
        private Employee Employee { get; set; }

        public InfoEmployeeWindow(Employee employee)
        {
            Employee = employee;

            InitializeComponent();

            LoadEmployee();
            LoadProductsInManuf();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void LoadEmployee()
        {
            textBlockFullName.Text = Employee.FullName;
            textBlockPhoneNumber.Text = Employee.PhoneNumber;
            textBlockPosition.Text = Employee.Position.ToString();
        }

        private void LoadProductsInManuf()
        {
            var productsInManuf = Employee.ProductsInManufacturing;

            var productsInManufNames = new List<string>();

            foreach (var productInManuf in productsInManuf)
            {
                productsInManufNames.Add(productInManuf.Name);
            }

            comboBoxWorkingOn.ItemsSource = productsInManufNames;
        }
    }
}
