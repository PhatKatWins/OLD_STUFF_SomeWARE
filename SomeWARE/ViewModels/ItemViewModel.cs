using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeWARE.ViewModels
{
    public class ItemViewModel
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public List<string> WarehouseCodes { get; set; }
        public List<int> WarehouseQuantities { get; set; }
        public List<List<string>> AislesPerWarehouse { get; set; }
        public List<List<string>> BinsPerWarehouse { get; set; }
        public List<string> Aisles { get; set; }
        public List<string> Bins { get; set; }
    }
}
