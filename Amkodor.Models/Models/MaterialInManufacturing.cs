using Amkodor.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.Models.Models
{
    public class MaterialInManufacturing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TypeEnum? Type { get; set; }
        public UnitEnum? Unit { get; set; }
        public int Count { get; set; }

        public int? WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }

        public int? ProductInManufacturingId { get; set; }
        public ProductInManufacturing? ProductInManufacturing { get; set; }
    }
}
