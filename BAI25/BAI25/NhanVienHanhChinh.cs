using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI25
{
    class NhanVienHanhChinh : CanBo
    {
        private string _PhongBan;

        public string PhongBan
        {
            get { return _PhongBan; }
            set { _PhongBan = value; }
        }

        private int _SoNgayCong;

        public int SoNgayCong
        {
            get { return _SoNgayCong; }
            set { _SoNgayCong = value; }
        }

        private string _ChucVu;

        public string ChucVu
        {
            get { return _ChucVu; }
            set { _ChucVu = value; }
        }

        private float _Luong;

        public float Luong
        {
            get { return _Luong; }
            set { _Luong = value; }
        }

        public override void Nhap()
        {
            base.Nhap();

            Console.Write("Phong ban: ");
            PhongBan = Console.ReadLine();

            Console.WriteLine("Chuc vu: ");
            Console.WriteLine("1. Truong phong");
            Console.WriteLine("2. Pho phong");
            Console.WriteLine("3. Nhan vien");
            int num = int.Parse(Console.ReadLine());
            ChucVu = formatChucVu(num);

            Console.Write("So ngay cong: ");
            do
            {
                try
                {
                    SoNgayCong = int.Parse(Console.ReadLine());
                    if (SoNgayCong < 0)
                    {
                        Console.WriteLine("So ngay cong phai lon hon 0");
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            while (SoNgayCong < 0);

            Luong = HeSoLuong * 730 + PhuCap + SoNgayCong * 30;
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.Write(String.Format("{0, -13}", PhongBan));
            Console.Write(String.Format("{0, -10}", ChucVu));
            Console.Write(String.Format("{0, -13}", SoNgayCong));
            Console.WriteLine(String.Format("{0, -15:0,0 vnd}", Luong));
        }   

        public string formatChucVu(int num)
        {
            switch (num)
            {
                case 1:
                    return "Truong phong";
                case 2:
                    return "Pho phong";
                case 3:
                    return "Nhan vien";
                default: return "Khong co trinh do";
            }
        }
    }
}
