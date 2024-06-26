﻿using System.Windows;
using Amkodor.Common.DTOs;
using Amkodor.ConnectionServices;

namespace Amkodor.Windows
{
    public partial class AuthWindow : Window
    {
        private readonly AuthConnectionService _authConnectionService;

        public AuthWindow()
        {
            InitializeComponent();

            _authConnectionService = new AuthConnectionService();
        }

        private async void ButtonEnter_Click(object sender, RoutedEventArgs e)
        {
            textboxLogin.Text = textboxLogin.Text.Trim();
            passwordBox.Password = passwordBox.Password.Trim();

            if (!string.IsNullOrEmpty(textboxLogin.Text) && !string.IsNullOrEmpty(passwordBox.Password))
            {
                try
                {
                    var userDto = new UserDto
                    {
                        Login = textboxLogin.Text,
                        Password = passwordBox.Password,
                    };

                    var auth = await _authConnectionService.IsAuth(userDto);

                    if (auth)
                    {
                        new MainWindow().Show();

                        Close();
                    }
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
