using Amkodor.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.Models.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TypeEnum? Type { get; set; }
        public UnitEnum? Unit { get; set; }
        public int Count { get; set; }

        public int? WarehouseId { get; set; }
        public Warehouse? Warehouse { get; set; }
    }
}
