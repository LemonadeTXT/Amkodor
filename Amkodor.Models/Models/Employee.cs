using Amkodor.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.Models.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public PositionEnum? Position { get; set; }

        public List<ProductInManufacturing>? ProductsInManufacturing { get; set; } = new();
    }
}
