using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.Models.Models
{
    public class ProductInBuilding
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Readiness { get; set; }
        public DateTime DeadLine { get; set; }
        public List<Employee>? Employees { get; set; }
    }
}
