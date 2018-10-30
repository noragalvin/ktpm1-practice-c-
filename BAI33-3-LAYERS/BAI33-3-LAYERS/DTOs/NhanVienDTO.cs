using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class NhanVienDTO
    {
        public int ID { get; set; }
        public string HoTen { get; set;}
        public string Khoa_PhongBan { get; set; }
        public int TrinhDo_ChucVu { get; set; }
        public int PhuCap { get; set; }
        public int SoTietDay_SoNgayCong { get; set; }
        public float HeSoLuong { get; set; }
        public float TongLuong { get; set; }
        public int LoaiNhanVien { get; set; }
        public NhanVienDTO() { }
        public NhanVienDTO(string HoTen, string Khoa_PhongBan, int TrinhDo_ChucVu,
            int PhuCap, int SoTietDay_SoNgayCong, float HeSoLuong, float TongLuong,
            int LoaiNhanVien)
        {
            this.HoTen = HoTen;
            this.Khoa_PhongBan = Khoa_PhongBan;
            this.TrinhDo_ChucVu = TrinhDo_ChucVu;
            this.PhuCap = PhuCap;
            this.SoTietDay_SoNgayCong = SoTietDay_SoNgayCong;
            this.HeSoLuong = HeSoLuong;
            this.TongLuong = TongLuong;
            this.LoaiNhanVien = LoaiNhanVien;
        }

        public NhanVienDTO(int ID, string HoTen, string Khoa_PhongBan, int TrinhDo_ChucVu,
            int PhuCap, int SoTietDay_SoNgayCong, float HeSoLuong, float TongLuong,
            int LoaiNhanVien)
        {
            this.ID = ID;
            this.HoTen = HoTen;
            this.Khoa_PhongBan = Khoa_PhongBan;
            this.TrinhDo_ChucVu = TrinhDo_ChucVu;
            this.PhuCap = PhuCap;
            this.SoTietDay_SoNgayCong = SoTietDay_SoNgayCong;
            this.HeSoLuong = HeSoLuong;
            this.TongLuong = TongLuong;
            this.LoaiNhanVien = LoaiNhanVien;
        }


        public NhanVienDTO(int p)
        {
            // TODO: Complete member initialization
            this.ID = p;
        }

    }
}
