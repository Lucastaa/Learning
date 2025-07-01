using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaiTap
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Occupation { get; set; }
        public int Age { get; set; }
        public int CompanyId { get; set; }
        public override string ToString()
        {
            return $"{FirstName} {LastName}, {Occupation}, Age: {Age}, Company ID: {CompanyId}";
        }

    }
}
