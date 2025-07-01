^!s::
InputBox, userInput, Gõ mã
if (userInput = "SinhVien")
{
    SendRaw,
(
	using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

namespace Lab10
{
    class SinhVien
    {
        public int MSSV { get; set; }
        public string HoTen { get; set; }
        public int Lop { get; set; }
        public double Diem { get; set; }
        public SinhVien(int mssv, string hoten, int lop, double diem)
        {
            MSSV = mssv;
            HoTen = hoten;
            Lop = lop;
            Diem = diem;
        }
        public override string ToString()
        {
            return $"{MSSV} - Họ tên: {HoTen}, Lớp: {Lop}, Điểm: {Diem}";
        }
    }
}

)
}
else if (userInput = "main")
{
    SendRaw,
(
	using Lab10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        var sinhVienList = new List<SinhVien>
        {
            new SinhVien(101, "MeiMei", 10, 8),
            new SinhVien(102, "Gojo", 8, 5),
            new SinhVien(103, "Geto", 9, 10)
        };

        var query = from n in sinhVienList
                    where n.Diem < 6.5
                    select new { n.HoTen, n.Diem};
        foreach (var n in query) Console.WriteLine(n);
    }
}
)
}
else if (userInput = "nangcao")
{
    SendRaw,
(
    a
)
}
else if (userInput = "reverse")
{
    SendRaw,
(
    List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
    var reverseList = list. AsEnumerable() .Reverse();

    var reversedPeopleLinq = people. AsEnumerable() .Reverse();
    Console WriteLine("\nThứ tự đảo ngược (LINQ Reverse) ---"); foreach (var p in reversedPeopleLinq)
    Console WriteLine($"- {p. FirstName}");
}
)
}
else if (userInput = "grouped")
{
    SendRaw,
(
    List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };
    var groupedNumbers = list.GroupBy(n => n ? 2 == 0 ? "Even" : "Odd")
    
    foreach (var group in groupedNumbers)
    {
        Console.WriteLine($"Group: {group.Key}")
    }
    foreach (var number in group)
    {
        Console.WriteLine(number);
    }
)
}
else if (userInput = "nangcao")
{
    SendRaw,
(
    asdasd
)
}
return