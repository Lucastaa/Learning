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
        public int MaNganh { get; set; }
        public SinhVien(int mssv, string hoten, int lop, double diem, int maNganh)
        {
            MSSV = mssv;
            HoTen = hoten;
            Lop = lop;
            Diem = diem;
            MaNganh = maNganh;
        }
        public override string ToString()
        {
            return $"{MSSV} - Họ tên: {HoTen}, Lớp: {Lop}, Điểm: {Diem}, Ngành {MaNganh}";
        }
    }
}
