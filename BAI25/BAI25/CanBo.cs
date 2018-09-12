
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAI25
{
    class CanBo
    {
        //virtual ~CanBo() { }

        protected string _HoTen;

        public string HoTen
        {
            get { return _HoTen; }
            set { _HoTen = value; }
        }

        protected float _HeSoLuong;

        public float HeSoLuong
        {
            get { return _HeSoLuong; }
            set { _HeSoLuong = value; }
        }

        protected float _PhuCap;

        public float PhuCap
        {
            get { return _PhuCap; }
            set { _PhuCap = value; }
        }

        virtual public void Nhap()
        {
            Console.Write("Ho va ten: ");
            HoTen = Console.ReadLine();

            Console.Write("He so luong: ");
            do
            {
                try
                {
                    HeSoLuong = float.Parse(Console.ReadLine());
                    if (HeSoLuong <= 0) {
                        Console.WriteLine("He so luong phai > 0");
                    }
                }
                catch(Exception)
                {
                    throw;
                }
            }
            while (HeSoLuong <= 0);
        }

        virtual public void Xuat()
        {
            Console.Write(String.Format("{0, -15}", HoTen));
            Console.Write(String.Format("{0, -13}", HeSoLuong));
        }
    }
}
