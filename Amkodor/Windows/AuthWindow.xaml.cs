﻿using Amkodor.Models.Models;
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
using Amkodor.Common.DTOs;

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

        private void ButtonEnter_Click(object sender, RoutedEventArgs e)
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

                    var auth = _authService.Auth(userDto);

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
