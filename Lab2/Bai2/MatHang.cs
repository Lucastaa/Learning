using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bai2
{
    class MatHang
    {
        public int Ma { get; set; }
        public string Ten { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public MatHang(int ma, string ten, int soLuong, double donGia)
        {
            Ma = ma;
            Ten = ten;
            SoLuong = soLuong;
            DonGia = donGia;
        }
        public double ThanhTien()
        {
            return SoLuong * DonGia;
        }
        public static void ThemMatHang(List<MatHang> mathang)
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write("Bạn có muốn thêm mặt hàng mới không? (y/n): ");
                string choice = Console.ReadLine();
                if (choice.ToLower() == "y")
                {
                    Console.Write("Nhập mã hàng: ");
                    int ma = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Nhập tên hàng: ");
                    string ten = Console.ReadLine();
                    Console.Write("Nhập số lượng: ");
                    int soLuong = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Nhập đơn giá: ");
                    double donGia = Convert.ToDouble(Console.ReadLine());
                    MatHang mh = new MatHang(ma, ten, soLuong, donGia);
                    mathang.Add(mh);
                }
                else if (choice.ToLower() == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Lựa chọn không hợp lệ, vui lòng nhập 'y' hoặc 'n'.");
                }
            }
        }
        public static bool TimMatHang(List<MatHang> mathang)
        {
            Console.Write("Nhập mã hàng cần tìm: ");
            int ma = Convert.ToInt32(Console.ReadLine());
            MatHang mh = mathang.FirstOrDefault(m => m.Ma == ma);
            if (mh != null)
            {

                return true;
                //Console.WriteLine($"Mặt hàng tìm thấy: {mh}");
                //Console.WriteLine("____========================____");
                //Console.WriteLine($"Tiến hành xóa mặt hàng.");
                //XoaMatHang(mathang, ma);
                //Console.WriteLine("Thành công.");
                //Console.WriteLine("____========================____");
            }
            else
            {
                return false;
                //Console.WriteLine("Không tìm thấy mặt hàng với mã này.");
            }
        }
        public static void XoaMatHang(List<MatHang> mathang)
        {
            Console.Write("Nhập mã hàng cần xóa: ");
            int ma = Convert.ToInt32(Console.ReadLine());
            MatHang mh = mathang.FirstOrDefault(m => m.Ma == ma);
            if (mh != null)
            {
                mathang.Remove(mh);
                Console.WriteLine($"Đã xóa mặt hàng: {mh}");
            }
            else
            {
                Console.WriteLine("Không tìm thấy mặt hàng với mã này để xóa.");
            }
        }
        public static void PrintCollection(List<MatHang> mathang)
        {
            Console.WriteLine("____========================____");
            Console.WriteLine("---->  Danh sách mặt hàng  <----");
            foreach (var mh in mathang)
            {
                Console.WriteLine(mh);
            }
            Console.WriteLine("____========================____");
        }
        public override string ToString()
        {
            return $"{Ten} - Số lượng: {SoLuong}, Đơn giá: {DonGia:C}, Thành tiền: {ThanhTien():C}";
        }
    }
}
