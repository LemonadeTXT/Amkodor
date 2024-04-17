using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.Models.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? ContactNumber { get; set; }
        public List<MaterialSupplier>? MaterialsSupplier { get; set; } = new();
    }
}
