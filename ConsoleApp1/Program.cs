using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8; // Đặt mã hóa đầu vào
            int[] a = { 10, 20, 30, 40 }; // Mảng với 4 phần tử bất kỳ

            try
            {
                Console.Write("Nhập chỉ mục của phần tử trong mảng (0-3): ");
                int index = Convert.ToInt32(Console.ReadLine());

                Console.Write("Nhập một số để chia: ");
                int divisor = Convert.ToInt32(Console.ReadLine());

                int result = a[index] / divisor;
                Console.WriteLine($"Kết quả phép chia: {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Lỗi: Không thể chia cho 0. " + ex.Message);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Lỗi: Chỉ mục nằm ngoài phạm vi của mảng. " + ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Lỗi: Vui lòng nhập một số nguyên hợp lệ. " + ex.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Lỗi không xác định: {e.Message}");
            }
        }
    }
}
