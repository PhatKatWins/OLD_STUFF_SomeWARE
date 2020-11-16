using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeWARE.Models
{
    public class Company 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LocationData { get; set; }

        public List<Warehouse> Warehouses { get; set; }
        public List<Item> Items { get; set; }

    }
}
