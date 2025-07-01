using BaiTap;
using System;

class Program 
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        List<int> numbers = new List<int>
        {
            -10, -5, -1, 0, 2, 7, 15, -3, 8, -7,
            12, 23, -18, 5, 9, -22, 30, 17, -4, 6,
            11, -13, 19, 25, -8, 3, 14, -16, 21, 4,
            -2, 27, -9, 16, 20, -6, 13, 22, -11, 18
        };
        //
        var timSo = from n in numbers
                    where n > 0 && n <= 12
                    select n;
        var timSo2 = timSo.OrderBy(so => so).ToList();
        Console.WriteLine("Các số dương nhỏ hơn 12 là:");
        foreach (var num in timSo2) Console.WriteLine(num);

        //Tim so lambda
        var timSoLambda = numbers.Where(n => n > 0 && n <= 12).OrderBy(so => so).ToList();
        Console.WriteLine("Các số dương nhỏ hơn 12 (sử dụng Lambda):");
        foreach (var num in timSoLambda) Console.WriteLine(num);

        //
        var timSo3 = from n in numbers
                     where n > 10
                     let n2 = n * n
                     select n2;
        Console.WriteLine("Các số dương lớn hơn 10 là:");
        foreach (var num in timSo3) Console.WriteLine(num);

        //Tim so lambda 2
        var timSoLambda2 = numbers.Where(n => n > 10).Select(n => n * n).ToList();
        Console.WriteLine("Các số dương lớn hơn 10 (sử dụng Lambda):");
        foreach (var num in timSoLambda2) Console.WriteLine(num);

        var peopletest = new List<Person>
    {
        new Person { FirstName = "Eric", LastName = "Fleming", Occupation = "Dev", Age = 24, CompanyId = 1 },
        new Person { FirstName = "Steve", LastName = "Smith", Occupation = "Manager", Age = 40, CompanyId = 1 },
        new Person { FirstName = "Brendan", LastName = "Enrick", Occupation = "Dev", Age = 30, CompanyId = 2 },
        new Person { FirstName = "Jane", LastName = "Doe", Occupation = "Dev", Age = 35, CompanyId = 1 },
        new Person { FirstName = "Samantha", LastName = "Jones", Occupation = "Dev", Age = 24, CompanyId = 2 },
        new Person { FirstName = "Tom", LastName = "Henderson", Occupation = "QA", Age = 28, CompanyId = 1 },
        new Person { FirstName = "Anna", LastName = "Nguyen", Occupation = "HR", Age = 31, CompanyId = 3 },
        new Person { FirstName = "Mark", LastName = "Tran", Occupation = "Dev", Age = 26, CompanyId = 1 },
        new Person { FirstName = "Emily", LastName = "Clark", Occupation = "Manager", Age = 38, CompanyId = 2 },
        new Person { FirstName = "John", LastName = "Phan", Occupation = "QA", Age = 29, CompanyId = 3 },
        new Person { FirstName = "Chris", LastName = "Lee", Occupation = "Support", Age = 32, CompanyId = 2 },
        new Person { FirstName = "Tina", LastName = "Vo", Occupation = "HR", Age = 36, CompanyId = 1 },
        new Person { FirstName = "Alex", LastName = "Khan", Occupation = "Dev", Age = 23, CompanyId = 3 },
        new Person { FirstName = "Natalie", LastName = "Wang", Occupation = "Manager", Age = 41, CompanyId = 2 },
        new Person { FirstName = "Brian", LastName = "Hoang", Occupation = "Dev", Age = 27, CompanyId = 1 },
        new Person { FirstName = "Lucy", LastName = "Kim", Occupation = "Dev", Age = 29, CompanyId = 3 },
        new Person { FirstName = "Victor", LastName = "Ng", Occupation = "DevOps", Age = 33, CompanyId = 2 },
        new Person { FirstName = "Rachel", LastName = "Ly", Occupation = "QA", Age = 30, CompanyId = 1 },
        new Person { FirstName = "Tommy", LastName = "Pham", Occupation = "Support", Age = 27, CompanyId = 3 },
        new Person { FirstName = "Jasmine", LastName = "Le", Occupation = "Dev", Age = 24, CompanyId = 1 },
        new Person { FirstName = "Daniel", LastName = "Nguyen", Occupation = "Dev", Age = 26, CompanyId = 2 },
        new Person { FirstName = "Linda", LastName = "Ngoc", Occupation = "HR", Age = 39, CompanyId = 3 },
        new Person { FirstName = "Peter", LastName = "Lam", Occupation = "QA", Age = 35, CompanyId = 1 },
        new Person { FirstName = "Sophia", LastName = "Dao", Occupation = "Manager", Age = 42, CompanyId = 2 },
        new Person { FirstName = "Albert", LastName = "Vo", Occupation = "Dev", Age = 25, CompanyId = 3 },
        new Person { FirstName = "Mia", LastName = "Pham", Occupation = "Dev", Age = 23, CompanyId = 2 },
        new Person { FirstName = "Nathan", LastName = "Do", Occupation = "Support", Age = 34, CompanyId = 1 },
        new Person { FirstName = "Karen", LastName = "Tran", Occupation = "QA", Age = 28, CompanyId = 3 },
        new Person { FirstName = "Henry", LastName = "Bui", Occupation = "DevOps", Age = 31, CompanyId = 2 },
        new Person { FirstName = "Lily", LastName = "Mai", Occupation = "Manager", Age = 43, CompanyId = 1 },
        new Person { FirstName = "Dylan", LastName = "Nguyen", Occupation = "Dev", Age = 30, CompanyId = 3 },
        new Person { FirstName = "Isabella", LastName = "Pham", Occupation = "Dev", Age = 26, CompanyId = 2 },
        new Person { FirstName = "Jason", LastName = "Le", Occupation = "Support", Age = 29, CompanyId = 1 },
        new Person { FirstName = "Cindy", LastName = "Vo", Occupation = "QA", Age = 27, CompanyId = 3 },
        new Person { FirstName = "Kevin", LastName = "Tran", Occupation = "Dev", Age = 28, CompanyId = 2 },
        new Person { FirstName = "Amy", LastName = "Lam", Occupation = "Manager", Age = 37, CompanyId = 1 },
        new Person { FirstName = "Sean", LastName = "Hoang", Occupation = "DevOps", Age = 32, CompanyId = 3 },
        new Person { FirstName = "Nina", LastName = "Huynh", Occupation = "HR", Age = 33, CompanyId = 2 },
        new Person { FirstName = "Tony", LastName = "Ngoc", Occupation = "Dev", Age = 25, CompanyId = 1 },
        new Person { FirstName = "Grace", LastName = "Nguyen", Occupation = "Dev", Age = 26, CompanyId = 3 },
        new Person { FirstName = "David", LastName = "Ly", Occupation = "Support", Age = 30, CompanyId = 2 },
        new Person { FirstName = "Olivia", LastName = "Pham", Occupation = "Dev", Age = 24, CompanyId = 1 },
        new Person { FirstName = "Ethan", LastName = "Le", Occupation = "QA", Age = 28, CompanyId = 3 },
        new Person { FirstName = "Ashley", LastName = "Truong", Occupation = "Dev", Age = 22, CompanyId = 2 },
        new Person { FirstName = "Tyler", LastName = "Kim", Occupation = "Manager", Age = 39, CompanyId = 1 },
        new Person { FirstName = "Luna", LastName = "Vo", Occupation = "DevOps", Age = 34, CompanyId = 3 },
        new Person { FirstName = "Zack", LastName = "Nguyen", Occupation = "Dev", Age = 27, CompanyId = 2 },
        new Person { FirstName = "Bella", LastName = "Pham", Occupation = "Support", Age = 31, CompanyId = 1 }
    };

        var tuoi = peopletest.Where(p => p.Age > 25 && p.Age < 32)
                             .Select(p => new { p.FirstName, p.LastName, p.Occupation, p.Age })
                             .OrderBy(p => p.Age)
                             .ToList();
        Console.WriteLine("Những người có tuổi từ 25 đến 32 là:");
        foreach (var person in tuoi) Console.WriteLine(person);

        var ten = peopletest.Where(p => p.Age > 25 && p.Age < 32)
                             .Select(p => new { p.FirstName, p.LastName, p.Occupation, p.Age })
                             .OrderBy(p => p.LastName)
                             .ToList();

        var tuoiTen = peopletest
            .Where(p => p.Age > 25 && p.Age < 32)
            .Select(p => new { p.FirstName, p.LastName, p.Occupation, p.Age })
            .OrderBy(p => p.Age)
            .ThenBy(p => p.LastName)
            .ThenBy(p => p.FirstName)
            .ToList();
        Console.WriteLine("Những người có tuổi từ 25 đến 32 (sắp xếp theo tuổi, họ, tên) là:");
        foreach (var person in tuoiTen) Console.WriteLine(person);
        Console.WriteLine("Những người có tuổi từ 25 đến 32 (sắp xếp theo họ) là:");
        foreach (var person in ten) Console.WriteLine(person);
    }
}