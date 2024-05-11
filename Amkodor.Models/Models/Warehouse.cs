using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.Models.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Material>? Materials { get; set; } = new();
    }
}
