using Amkodor.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amkodor.Models.Models
{
    public class RequestMaterialSupplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TypeEnum? Type { get; set; }
        public UnitEnum? Unit { get; set; }

        [Column(TypeName = "money")]
        public decimal? PriceForOne { get; set; }
        public int? Count { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public bool? Approve { get; set; }

        public int? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
    }
}
