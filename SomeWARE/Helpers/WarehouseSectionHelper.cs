using SomeWARE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SomeWARE.Helpers
{
    public static class WarehouseSectionHelper
    {
        public static List<string> GetSections(int number, Order order)
        {
            var sections = new List<string>();

            if (order == Order.NUMERIC)
            {
                for (int i = 1; i <= number; i++)
                {
                    sections.Add(i.ToString());
                }
            }
            else
            {
                var letter = (int)'a';
                for (int i = 0; i < number; i++)
                {
                    sections.Add(((char)(letter + i)).ToString().ToUpper());
                }
            }

            return sections;
        }
    }
}
