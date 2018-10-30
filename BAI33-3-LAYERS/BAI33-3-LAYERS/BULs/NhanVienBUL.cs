using DALs;
using DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BULs
{
    public class NhanVienBUL
    {
        NhanVienDAL myNhanVienDAL = new NhanVienDAL();
        public List<NhanVienDTO> LayDanhSachNhanVien()
        {
            return myNhanVienDAL.DocBangNhanVien();
        }

        public void ThemMotNhanVien(NhanVienDTO aNV)
        {
            myNhanVienDAL.ThemNhanVien(aNV);
        }

        public List<NhanVienDTO> TimNhanVien(string ten)
        {
            return myNhanVienDAL.TimKiemNhanVien(ten);
        }

        public string NumberOfRecords(bool isSearch, string ten)
        {
            return myNhanVienDAL.CountRecords(isSearch, ten);
        }

        public void CurrentRecords(bool isSort, bool isSearch, string ten, DataSet ds, int firstRow, int pageSize)
        {
            myNhanVienDAL.CurrentRecords(isSort, isSearch, ten, ds, firstRow, pageSize);
        }

        public List<NhanVienDTO> SapXep()
        {
            return myNhanVienDAL.SapXep();
        }
    }
}
