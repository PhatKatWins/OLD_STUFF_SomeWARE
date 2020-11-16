using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeWARE.Models
{
    public class Availability
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string WarehouseCode { get; set; }
        public int Quantity { get; set; }
        public string Aisle { get; set; }
        public string Bin { get; set; }
    }
}
