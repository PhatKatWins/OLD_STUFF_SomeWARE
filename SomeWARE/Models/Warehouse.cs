using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeWARE.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Code { get; set; }
        public String LocationData { get; set; }


        public int Aisles { get; set; }
        public int BinsPerAisle { get; set; }
        public Order AisleOrder { get; set; }
        public Order BinOrder { get; set; }

    }
}
