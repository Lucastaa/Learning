using System;
using System.Text;

namespace Bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Write("Nhập số lượng phần tử n: ");
            int n = int.Parse(Console.ReadLine());

            List<int> numbers = new List<int>();
            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                numbers.Add(random.Next(100)); 
            }

            numbers.Sort();

            Console.WriteLine("Dãy sau khi sắp xếp:");
            foreach (int num in numbers)
            {
                Console.Write(num + " ");
            }
        }
    }
}
