using Amkodor.Pages;
using System.Windows;

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
            HideTextBlock();
        }

        private void ButtonSuppliers_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new SuppliersPage());
            HideTextBlock();
        }

        private void ButtonEmployees_Click(object sender, RoutedEventArgs e)
        {
            HideTextBlock();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButtonMaterials_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new MaterialsPage());
            HideTextBlock();
        }

        private void ButtonPurchaseRequest_Click(object sender, RoutedEventArgs e)
        {
            frame.Navigate(new MaterialsSuppliersPage());
            HideTextBlock();
        }

        private void HideTextBlock()
        {
            textBlockAdvice.Visibility = Visibility.Collapsed;
        }
    }
}