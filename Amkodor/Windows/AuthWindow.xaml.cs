using Amkodor.Models.Models;
using Amkodor.BusinessLogic.Interfaces;
using Amkodor.BusinessLogic.Services;
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

namespace Amkodor.Windows
{
    public partial class AuthWindow : Window
    {
        private readonly IAuthService _authService;

        public AuthWindow()
        {
            InitializeComponent();

            _authService = new AuthService();
        }

        private void Button_Enter(object sender, RoutedEventArgs e)
        {
            var user = new User
            {
                Login = textboxLogin.Text,
                Password = textboxPassword.Text,
            };

            var auth = _authService.Auth(user);

            if (auth)
            {
                new MainWindow().Show();

                Close();
            }
        }
    }
}
