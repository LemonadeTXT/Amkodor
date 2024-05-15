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

namespace Amkodor.AddWindows
{
    public partial class AddMaterialsForProdWindow : Window
    {
        private readonly MaterialConnectionService _materialConnectionService;
        private readonly MaterialInManufConnectionService _materialInManufConnectionService;
        private readonly ProductInManufacturing _productInManufacturing;

        private Material Material { get; set; }

        public AddMaterialsForProdWindow(MaterialConnectionService materialConnectionService, 
            Material material, 
            ProductInManufacturing productInManufacturing)
        {
            _materialConnectionService = materialConnectionService;
            _productInManufacturing = productInManufacturing;

            _materialInManufConnectionService = new MaterialInManufConnectionService();

            Material = material;

            InitializeComponent();

            LoadMaterial();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(textBoxCount.Text, out var count))
            {
                if (Material.Count >= count)
                {
                    var materialInManuf = new MaterialInManufacturing
                    {
                        Name = Material.Name,
                        Type = Material.Type,
                        Unit = Material.Unit,
                        Count = count,
                        WarehouseId = Material.WarehouseId,
                        ProductInManufacturingId = _productInManufacturing.Id,
                    };

                    Material.Count -= count;

                    _materialInManufConnectionService.Add(materialInManuf);
                    _materialConnectionService.Edit(Material);

                    Close();
                }
            }
        }

        private void LoadMaterial()
        {
            textBlockMaterial.Text = Material.Name;
        }
    }
}
