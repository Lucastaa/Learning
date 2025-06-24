namespace Lab6
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
            public static void ThemSinhVien(List<SinhVien> sinhvien)
            {
                for (int i = 0; i < 1000; i++)
                {
                    Console.Write("Bạn có muốn thêm sinh viên mới không? (y/n): ");
                    string choice = Console.ReadLine();
                    if (choice.ToLower() == "y")
                    {
                        Console.Write("Nhập mã sinh viên: ");
                        int mssv = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Nhập họ tên: ");
                        string hoten = Console.ReadLine();
                        Console.Write("Nhập lớp học: ");
                        int lop = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Nhập số điểm: ");
                        double diem = Convert.ToDouble(Console.ReadLine());
                        SinhVien sv = new SinhVien(mssv, hoten, lop, diem);
                        sinhvien.Add(sv);
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
            public static bool TimSinhVien(List<SinhVien> SinhVien)
            {
                Console.Write("Nhập mã sinh viên: ");
                int mssv = Convert.ToInt32(Console.ReadLine());
                SinhVien sv = SinhVien.FirstOrDefault(s => s.MSSV == mssv);
                if (sv != null)
                {

                    return true;
                }
                else
                {
                    return false;
                }
            }
            public static void XoaSinhVien(List<SinhVien> sinhvien)
            {
                Console.Write("Nhập mã số sinh viên cần xóa: ");
                int mssv = Convert.ToInt32(Console.ReadLine());
                SinhVien sv = sinhvien.FirstOrDefault(s => s.MSSV == mssv);
                if (sv != null)
                {
                    sinhvien.Remove(sv);
                    Console.WriteLine($"Đã thấy sinh viên: {sv}");
                }
                else
                {
                    Console.WriteLine("Không tìm thấy sinh viên với mã này để xóa.");
                }
            }
        public static void Top5SinhVien(List<SinhVien> sinhvien)
        {
            var top5 = sinhvien.OrderByDescending(s => s.Diem).Take(5).ToList();
            Console.WriteLine("Top 5 sinh viên có điểm cao nhất:");
            foreach (var sv in top5)
            {
                Console.WriteLine(sv);
            }
        }
            public override string ToString()
            {
                
                    return $"{MSSV} - Họ tên: {HoTen}, Lớp: {Lop}, Điểm: {Diem}";
                
            }
        }
    }
