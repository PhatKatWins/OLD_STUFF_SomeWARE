using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeWARE.Models
{
    public class Item 
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public List<Availability> Availabilities { get; set; }
    }
}
