﻿using Amkodor.AddWindows;
using Amkodor.ConnectionServices;
using Amkodor.EditWindows;
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
    public partial class MaterialsPage : Page
    {
        private readonly MaterialConnectionService _materialConnectionService;

        public MaterialsPage()
        {
            _materialConnectionService = new MaterialConnectionService();

            InitializeComponent();

            LoadDatagrid();
        }

        private void ButtonAddMaterial_Click(object sender, RoutedEventArgs e)
        {
            new AddMaterialWindow(_materialConnectionService).ShowDialog();
        }

        private void ButtonEditMaterial_Click(object sender, RoutedEventArgs e)
        {
            var material = (Material)dataGridMaterials.SelectedItem;

            if (material != null)
            {
                new EditMaterialWindow(_materialConnectionService, material).ShowDialog();
            }
        }

        private void ButtonDeleteMaterial_Click(object sender, RoutedEventArgs e)
        {
            var material = (Material)dataGridMaterials.SelectedItem;

            if (material != null)
            {
                _materialConnectionService.Delete(material);
            }
        }

        private async void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            dataGridMaterials.ItemsSource = await _materialConnectionService.GetAllMaterials();
        }

        private async void TextBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !string.IsNullOrEmpty(textBoxSearch.Text))
            {
                Search(textBoxSearch.Text);
            }
            else if (e.Key == Key.Enter && string.IsNullOrEmpty(textBoxSearch.Text))
            {
                dataGridMaterials.ItemsSource = await _materialConnectionService.GetAllMaterials();
            }
        }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            Search(textBoxSearch.Text);
        }

        private async void Search(string value)
        {
            if (textBoxSearch.Text != string.Empty)
            {
                dataGridMaterials.ItemsSource = await _materialConnectionService.Search(value);
            }
        }

        private async void LoadDatagrid()
        {
            dataGridMaterials.ItemsSource = await _materialConnectionService.GetAllMaterials();
        }
    }
}
