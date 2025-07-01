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
            new SinhVien(101, "MeiMei", 10, 10, 2),
            new SinhVien(102, "Gojo", 8, 5, 1),
            new SinhVien(103, "Geto", 9, 10, 2)
        };

        var query = from n in sinhVienList
                    where n.Diem < 6.5
                    select new { n.HoTen, n.Diem};
        foreach (var n in query) Console.WriteLine(n);

        var nganh = Nganh.GenerateMajors();
        var studentWithMajor = sinhVienList.Join(nganh, sv => sv.MaNganh, ng => ng.Id, (sv, ng) => new { sv.HoTen, ng.Name });
        var studentWithMajorQuery = from sv in sinhVienList
                                    join ng in nganh on sv.MaNganh equals ng.Id
                                    select new { sv.HoTen, ng.Name };
        foreach (var b in studentWithMajorQuery) Console.WriteLine(b);

        // Skip example: Skip the first 2 students
        var skippedStudents = sinhVienList.Skip(2);
        Console.WriteLine("Skip example:");
        foreach (var sv in skippedStudents)
        {
            Console.WriteLine(sv);
        }

        // Where example: Select students with Diem >= 8
        var highScoreStudents = sinhVienList.Where(sv => sv.Diem >= 8);
        Console.WriteLine("Where example:");
        foreach (var sv in highScoreStudents)
        {
            Console.WriteLine(sv);
        }

        // Select example: Project student names and scores
        var studentNamesAndScores = sinhVienList.Select(sv => new { sv.HoTen, sv.Diem });
        Console.WriteLine("Select example:");
        foreach (var item in studentNamesAndScores)
        {
            Console.WriteLine(item);
        }
        
        SinhVien firstOrDefault = sinhVienList.FirstOrDefault(sv => sv.Diem > 9);
        Console.WriteLine("FirstOrDefault example:");
        if (firstOrDefault != null)
        {
            Console.WriteLine(firstOrDefault);
        }
        else
        {
            Console.WriteLine("No student found with score > 9");
        }

        SinhVien lastOrDefault = sinhVienList.LastOrDefault(sv => sv.Diem > 9);
        Console.WriteLine("LastOrDefault example:");
        if (lastOrDefault != null)
        {
            Console.WriteLine(lastOrDefault);
        }
        else
        {
            Console.WriteLine("No student found with score > 9");
        }

        var singleOrDefault = sinhVienList.SingleOrDefault(sv => sv.MSSV == 101);
        Console.WriteLine("SingleOrDefault example:");
        if (singleOrDefault != null)
        {
            Console.WriteLine(singleOrDefault);
        }
        else
        {
            Console.WriteLine("No student found with MSSV = 101");
        }

        int num = sinhVienList.Count(sv => sv.Diem > 8);
        Console.WriteLine($"Number of students with score > 8: {num}");

        bool thereAreStudentsWithHighScore = sinhVienList.Any(sv => sv.Diem > 9);
        Console.WriteLine($"Are there any students with score > 9? {thereAreStudentsWithHighScore}");

        bool allStudentsHaveHighScore = sinhVienList.All(sv => sv.Diem > 5);
        Console.WriteLine($"Do all students have score > 5? {allStudentsHaveHighScore}");

        var studentArray = sinhVienList.ToArray();
        Console.WriteLine("Students in array format:");
        foreach (var sv in studentArray)
        {
            Console.WriteLine(sv);
        }

        double averageScore = sinhVienList.Average(sv => sv.Diem);
        string allNames = sinhVienList.Aggregate("", (current, sv) => current + (sv.HoTen + ", "));
        Console.WriteLine($"Average score of students: {averageScore}");
        Console.WriteLine($"All student names: {allNames.TrimEnd(',', ' ')}");

        var combined = sinhVienList.Where(p => p.MaNganh == 2 && p.Diem > 8)
                                   .Select(p => new { p.HoTen, p.Diem });
        Console.WriteLine("Students in major 2 with score > 8:");
        foreach (var item in combined)
        {
            Console.WriteLine(item);
        }

        var result = nganh.GroupJoin(sinhVienList, ng => ng.Id, sv => sv.MaNganh, (ng, svs) => new { ng.Name, Students = svs });
        foreach (var c in result) Console.WriteLine(c);

        List<int> list = new List<int> { 1, 2, 3, 4, 8, 6, 7, 5, 9, 10 };
        var sortedNumbers = list.OrderBy(n => n);
        foreach (var n in sortedNumbers)
        {
            Console.WriteLine(n);
        }

        List<int> list2 = new List<int> { 1, 2, 3, 4, 8, 6, 7, 5, 9, 10 };
        var sortedNumbers2 = list2.OrderByDescending(n => n);
        foreach (var n in sortedNumbers2)
        {
            Console.WriteLine(n);
        }

        //Mệnh đề Query
        var StudentsQuery = from sv in sinhVienList
                                    where sv.Diem > 8
                                    orderby sv.HoTen
                                    select new { sv.HoTen, sv.Diem };
        foreach (var student in StudentsQuery)
        {
            Console.WriteLine(student);
        }

        //Let
        var letQuery = from sv in sinhVienList
                       let fullName = $"{sv.HoTen} - {sv.Diem}"
                       select fullName;

        var nhanHaiDiem = from sv in sinhVienList
                          let diemNhanHai = sv.Diem * 2
                          where diemNhanHai > 10
                          select new { sv.HoTen, DiemNhanHai = diemNhanHai };

        Console.WriteLine("Let query results:");
        foreach (var item in letQuery)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Let example:");
        foreach (var item in nhanHaiDiem)
        {
            Console.WriteLine($"{item.HoTen} - Điểm nhân 2: {item.DiemNhanHai}");
        }
    }
}