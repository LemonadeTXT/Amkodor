using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.Common.DTOs
{
    public class ProductInManufacturingDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Readiness { get; set; }
        public DateTime? DeadLine { get; set; }
        public int MaterialInManufacturingCount { get; set; }
        public int EmployeesCount { get; set; }
    }
}
