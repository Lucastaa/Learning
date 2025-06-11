using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public class NotNegativeException : Exception
        {
            public NotNegativeException(string message) : base(message) { }
        }
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8; // Đặt mã hóa đầu vào
            Console.Write("Nhập vào số nguyên x: ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nhập vào số nguyên y: ");
            int y = Convert.ToInt32(Console.ReadLine());
            try
            {
                double h = Calculation(x, y);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Lỗi: Không thể chia cho 0. " + ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Lỗi: Vui lòng nhập một số nguyên hợp lệ. " + ex.Message);
            }
            catch (NotNegativeException ex)
            {
                Console.WriteLine("Lỗi biểu thức trong căn bắt buộc phải lớn hơn 0. " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi không xác định: {ex.Message}");
            }
            finally
            {
                Console.WriteLine($"Kết quả phép tính: {Calculation(x, y)}");
            }
        }
        
        static double Calculation(int x, int y)
        {
            double tuso = (3 * x) + (2 * y);
            double mauso = (2 * x) - y;
            if (mauso == 0)
            {
                throw new DivideByZeroException("Mẫu số không được bằng 0.");
            }
            if (tuso < 0 || mauso < 0)
            {
                throw new NotNegativeException("Tử số và mẫu số phải lớn hơn hoặc bằng 0.");
            }
            return Math.Sqrt(tuso / mauso);
        }
    }
}
