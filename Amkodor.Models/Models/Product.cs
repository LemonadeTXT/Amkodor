using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.Models.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }

        [Column(TypeName = "money")]
        public decimal? CostPrice { get; set; }
        public DateTime BuildDate { get; set; }
    }
}
