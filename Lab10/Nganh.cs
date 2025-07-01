using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    class Nganh
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nganh()
        {
            Id = 0;
            Name = string.Empty;
        }
        public static List<Nganh> GenerateMajors()
        {
            return new List<Nganh> {
                new Nganh { Id = 1, Name = "CNTT" },
                new Nganh { Id = 2, Name = "Kinh tế" },
            };
        }
    }
}
