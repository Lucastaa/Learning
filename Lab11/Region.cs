using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    public  class Region
    {
        public string Name { get; set; }
        public static List<Region> GenerateRegion()
        {
            return new List<Region> {
                new Region { Name = "Asia" },
                new Region { Name = "Europe" },
                new Region { Name = "America" },
            };
        }
    }
}
