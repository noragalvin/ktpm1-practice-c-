using DTOs;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALs
{
    public class NhanVienDAL
    {
        private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ChuoiKetNoi"].ToString());
        public List<NhanVienDTO> DocBangNhanVien()
        {
            List<NhanVienDTO> dsNhanVien = new List<NhanVienDTO>();
            conn.Open();
            string sqlSELECT = "SELECT * FROM tblNhanVien";
            SqlCommand cmd = new SqlCommand(sqlSELECT, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            /*DataTable dt = new DataTable();
            dt.Load(dr);
            conn.Close();
            return dt;*/
            
            while (dr.Read())
            {
                NhanVienDTO aNhanVien = new NhanVienDTO(
                    dr["HoTen"].ToString(),
                    dr["Khoa_PhongBan"].ToString(),
                    Convert.ToInt32(dr["TrinhDo_ChucVu"]),
                    Convert.ToInt32(dr["PhuCap"]),
                    Convert.ToInt32(dr["SoTietDay_SoNgayCong"]),
                    Convert.ToSingle(dr["HeSoLuong"]),
                    Convert.ToSingle(dr["TongLuong"]),
                    Convert.ToInt32(dr["LoaiNhanVien"]));
                dsNhanVien.Add(aNhanVien);
            }
            conn.Close();

            return dsNhanVien;
        }

        public void ThemNhanVien(NhanVienDTO nvMoi)
        {
            conn.Open();

            string sqlINSERT = "INSERT INTO tblNhanVien VALUES(@hoten,@k_pb,@td_cv,@pc,@std_snc,@hsl,@tl,@lnv)";
            SqlCommand cmd = new SqlCommand(sqlINSERT, conn);
            cmd.Parameters.AddWithValue("hoten", nvMoi.HoTen);
            cmd.Parameters.AddWithValue("k_pb", nvMoi.Khoa_PhongBan);
            cmd.Parameters.AddWithValue("td_cv", nvMoi.TrinhDo_ChucVu);
            cmd.Parameters.AddWithValue("pc", nvMoi.PhuCap);
            cmd.Parameters.AddWithValue("std_snc", nvMoi.SoTietDay_SoNgayCong);
            cmd.Parameters.AddWithValue("hsl", nvMoi.HeSoLuong);
            cmd.Parameters.AddWithValue("tl", nvMoi.TongLuong);
            cmd.Parameters.AddWithValue("lnv", nvMoi.LoaiNhanVien);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public List<NhanVienDTO> TimKiemNhanVien(string ten)
        {
            conn.Open();
            string sqlSELECT = "SELECT * FROM tblNhanVien WHERE HoTen LIKE @search";
            SqlCommand cmd = new SqlCommand(sqlSELECT, conn);
            cmd.Parameters.AddWithValue("search", "%" + ten + "%");
            SqlDataReader dr = cmd.ExecuteReader();
            List<NhanVienDTO> ds = new List<NhanVienDTO>();
            while (dr.Read())
            {
                NhanVienDTO aNV = new NhanVienDTO(
                    Convert.ToInt32(dr["ID"]),
                    dr["HoTen"].ToString(),
                    dr["Khoa_PhongBan"].ToString(),
                    Convert.ToInt32(dr["TrinhDo_ChucVu"]),
                    Convert.ToInt32(dr["PhuCap"]),
                    Convert.ToInt32(dr["SoTietDay_SoNgayCong"]),
                    Convert.ToSingle(dr["HeSoLuong"]),
                    Convert.ToSingle(dr["TongLuong"]),
                    Convert.ToInt32(dr["LoaiNhanVien"]));
                ds.Add(aNV);
            }
            conn.Close();
            return ds;
        }

        public string CountRecords(bool isSearch, string ten)
        {
            conn.Open();
            object count;
            SqlCommand cmd;
            if(isSearch == true)
            {
                string sql = "SELECT COUNT(*) FROM tblNhanVien WHERE HoTen LIKE '%"+ten+"%'" ;
                cmd = new SqlCommand(sql, conn);
                //cmd.Parameters.AddWithValue("search", "%" + ten + "%");
                count = cmd.ExecuteScalar();
                conn.Close();
                return count.ToString();
            }
            string sqlCOUNT = "SELECT COUNT(*) FROM tblNhanVien";
            cmd = new SqlCommand(sqlCOUNT, conn);
            count = cmd.ExecuteScalar();
            conn.Close();
            return count.ToString();
            
        }



        public void CurrentRecords(bool isSort, bool isSearch, string ten, DataSet ds, int firstRow, int pageSize)
        {
            string sql = "";
            SqlDataAdapter da;
            if (isSort == true)
            {
                sql = "SELECT * FROM tblNhanVien ORDER BY TongLuong ASC";
                da = new SqlDataAdapter(sql, conn);
                da.Fill(ds, firstRow, pageSize, "tblNhanVien");
                return;
            }
            if (isSearch == true)
            {
                sql = "SELECT * FROM tblNhanVien WHERE HoTen LIKE @search";
                da = new SqlDataAdapter(sql, conn);
                da.SelectCommand.Parameters.AddWithValue("@search", "%" + ten + "%");
                da.Fill(ds, firstRow, pageSize, "tblNhanVien");
                return;
            }
            sql = "select * from tblNhanVien";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, firstRow, pageSize, "tblNhanVien");
        }

        public List<NhanVienDTO> SapXep()
        {
            List<NhanVienDTO> dsNhanVien = new List<NhanVienDTO>();
            conn.Open();
            string sqlSELECT = "SELECT * FROM tblNhanVien ORDER BY TongLuong ASC";
            SqlCommand cmd = new SqlCommand(sqlSELECT, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                NhanVienDTO aNhanVien = new NhanVienDTO(
                    dr["HoTen"].ToString(),
                    dr["Khoa_PhongBan"].ToString(),
                    Convert.ToInt32(dr["TrinhDo_ChucVu"]),
                    Convert.ToInt32(dr["PhuCap"]),
                    Convert.ToInt32(dr["SoTietDay_SoNgayCong"]),
                    Convert.ToSingle(dr["HeSoLuong"]),
                    Convert.ToSingle(dr["TongLuong"]),
                    Convert.ToInt32(dr["LoaiNhanVien"]));
                dsNhanVien.Add(aNhanVien);
            }
            conn.Close();

            return dsNhanVien;
        }

        

    }
}
