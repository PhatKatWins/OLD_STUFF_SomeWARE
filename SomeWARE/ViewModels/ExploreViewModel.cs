using SomeWARE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomeWARE.ViewModels
{
    public class ExploreViewModel
    {
        public string Code { get; set; }
        public ICollection<string> Aisles { get; set; }
        public ICollection<string> Bins { get; set; }

    }
}
