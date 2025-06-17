using Bai2;
using System.Collections;
using System.Text;
using System.Transactions;

class Program {
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        List<MatHang> mathang = new List<MatHang>();
        mathang.Add(new MatHang(1, "Bánh mì", 10, 5000));
        mathang.Add(new MatHang(2, "Sữa tươi", 5, 20000));
        mathang.Add(new MatHang(3, "Trái cây", 20, 15000));
        mathang.Add(new MatHang(4, "Nước ngọt", 15, 10000));

        MatHang.ThemMatHang(mathang);
        MatHang.PrintCollection(mathang);
        Console.WriteLine(MatHang.TimMatHang(mathang));
        MatHang.XoaMatHang(mathang);
        MatHang.PrintCollection(mathang);
    }
}