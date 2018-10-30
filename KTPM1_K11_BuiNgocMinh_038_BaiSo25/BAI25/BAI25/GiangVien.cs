using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI25
{
    class GiangVien : CanBo
    {
        private string _Khoa;

        public string Khoa
        {
            get { return _Khoa; }
            set { _Khoa = value; }
        }

        private string _TrinhDo;

        public string TrinhDo
        {
            get { return _TrinhDo; }
            set { _TrinhDo = value; }
        }

        private int _SoTietDay;

        public int SoTietDay
        {
            get { return _SoTietDay; }
            set { _SoTietDay = value; }
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

            Console.Write("Khoa: ");
            Khoa = Console.ReadLine();

            Console.WriteLine("Trinh do: ");
            Console.WriteLine("1. Cu nhan");
            Console.WriteLine("2. Thac si");
            Console.WriteLine("3. Tien si");
            int num = int.Parse(Console.ReadLine());
            TrinhDo = formatTrinhDo(num);
            PhuCap = formatPhuCap(num);

            Console.Write("So tiet day: ");
            do
            {
                try
                {
                    SoTietDay = int.Parse(Console.ReadLine());
                    if (SoTietDay < 0)
                    {
                        Console.WriteLine("So tiet day phai lon hon 0");
                    }
                }
                catch (OverflowException oe)
                {
                    Console.WriteLine("Qua gioi han cua du lieu");
                }
                catch (FormatException fe)
                {
                    Console.WriteLine("So tiet day phai la so");
                }
            }
            while (SoTietDay < 0);

            Luong = HeSoLuong * 730 + PhuCap + SoTietDay * 45;
        }

        public override void Xuat()
        {
            base.Xuat();
            Console.Write(String.Format("{0, -13}", Khoa));
            Console.Write(String.Format("{0, -15}", TrinhDo));
            Console.Write(String.Format("{0, -13}", SoTietDay));
            Console.WriteLine(String.Format("{0, -15:0,0 vnd}", Luong));
        }

        public string formatTrinhDo(int num)
        {
            switch(num)
            {
                case 1:
                    return "Cu nhan";
                case 2:
                    return "Thac si";
                case 3:
                    return "Tien si";
                default: return "Khong co trinh do";
            }
        }

        public int formatPhuCap(int num)
        {
            switch (num)
            {
                case 1: return 2000;
                case 2: return 1000;
                case 3: return 500;
                default: return 0;

            }
        }
    }
}
