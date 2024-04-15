using Amkodor.Pages;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Amkodor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonWarehouses_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new WarehousesPage());
        }

        private void ButtonSuppliers_Click(object sender, RoutedEventArgs e)
        {

        }
       
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}