using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.Models.Models
{
    public class ProductInManufacturing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string? Readiness { get; set; }
        public DateTime? DeadLine { get; set; }
        public bool InManufacturing { get; set; }

        public List<MaterialInManufacturing>? MaterialInManufacturing { get; set; } = new();
        public List<Employee>? Employees { get; set; } = new();
    }
}
