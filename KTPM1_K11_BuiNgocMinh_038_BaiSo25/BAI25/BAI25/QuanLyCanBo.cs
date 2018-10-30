using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI25
{
    class QuanLyCanBo
    {
        private List<GiangVien> DanhSachGiangVien = new List<GiangVien>();
        private List<NhanVienHanhChinh> DanhSachNhanVien = new List<NhanVienHanhChinh>();
        private int SoLuongCanBo;


        public void NhapCanBo()
        {
            int SoLuongNhanVien = 0;
            int SoLuongGiangVien = 0;
            string choose;

            Console.Write("Nhap so luong can bo: ");

            do
            {
                try
                {
                    SoLuongCanBo = Convert.ToInt32(Console.ReadLine());
                    if (SoLuongCanBo <= 0)
                    {
                        Console.WriteLine("So luong can bo phai lon hon 0");
                    }
                }
                catch (OverflowException oe)
                {
                    Console.WriteLine("Qua gioi han cua du lieu");
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("So luong phai la so");
                }
            }
            while (SoLuongCanBo <= 0);


            do
            {
                try
                {
                    MainMenu();

                    choose = Console.ReadLine();

                    if (choose[0] != '0' && choose[0] != '1')
                    {
                        Console.WriteLine("Nhap lai: ");
                    }

                    switch (choose[0])
                    {
                        case '1':
                            ++SoLuongGiangVien;
                            GiangVien gv = new GiangVien();
                            Console.WriteLine("\nNhap giang vien thu {0}", SoLuongGiangVien);
                            gv.Nhap();
                            DanhSachGiangVien.Add(gv);
                            break;

                        case '2':
                            ++SoLuongNhanVien;
                            NhanVienHanhChinh nv = new NhanVienHanhChinh();
                            Console.WriteLine("\nNhap nhan vien thu {0}", SoLuongNhanVien);
                            nv.Nhap();
                            DanhSachNhanVien.Add(nv);
                            break;
                        default: break;
                    }
                }
                catch(IndexOutOfRangeException)
                {
                    Console.WriteLine("Ban vua nhap chuoi rong");
                }

            } while (!isFull(SoLuongGiangVien, SoLuongNhanVien, SoLuongCanBo));
        }


        public void XuatCanBo()
        {
            Console.WriteLine("\nDanh sach giang vien: ");
            Console.Write(String.Format("{0, -15}", "Ten"));
            Console.Write(String.Format("{0, -13}", "He so luong"));
            Console.Write(String.Format("{0, -13}", "Khoa"));
            Console.Write(String.Format("{0, -15}", "Trinh do"));
            Console.Write(String.Format("{0, -13}", "So tiet day"));
            Console.WriteLine(String.Format("{0, -15}", "Luong"));
            foreach (GiangVien item in DanhSachGiangVien)
                item.Xuat();

            Console.WriteLine("\nDanh sach nhan vien: ");
            Console.Write(String.Format("{0, -15}", "Ten"));
            Console.Write(String.Format("{0, -13}", "He so luong"));
            Console.Write(String.Format("{0, -13}", "Phong ban"));
            Console.Write(String.Format("{0, -15}", "Chuc vu"));
            Console.Write(String.Format("{0, -13}", "So ngay cong"));
            Console.WriteLine(String.Format("{0, -15}", "Luong"));
            foreach (NhanVienHanhChinh item in DanhSachNhanVien)
                item.Xuat();
        }

        public void MainMenu()
        {
            Console.WriteLine("");
            Console.WriteLine("1. Nhap Giang Vien");
            Console.WriteLine("2. Nhap Nhan Vien Hanh Chinh");
            Console.Write("Nhap lua chon cua ban: ");
        }

        public bool isFull(int a, int b, int c)
        {
            return c == a + b;
        }

        public void TimKiemCanBo()
        {
            string TenSearch, PhongBanSearch;
            Console.Write("\nNhap ten can tim kiem: ");
            TenSearch = Console.ReadLine();

            Console.Write("Nhap phong ban can tim kiem: ");
            PhongBanSearch = Console.ReadLine();


            NhanVienHanhChinh Result = DanhSachNhanVien.Find(item => (item.HoTen == TenSearch) && (item.PhongBan == PhongBanSearch));

            Console.WriteLine("\nNhan vien can tim kiem: ");
            Console.Write(String.Format("{0, -15}", "Ten"));
            Console.Write(String.Format("{0, -13}", "He so luong"));
            Console.Write(String.Format("{0, -13}", "Phong ban"));
            Console.Write(String.Format("{0, -10}", "Chuc vu"));
            Console.Write(String.Format("{0, -13}", "So ngay cong"));
            Console.WriteLine(String.Format("{0, -15}", "Luong"));
            Result.Xuat();

        }



        
    }
}
