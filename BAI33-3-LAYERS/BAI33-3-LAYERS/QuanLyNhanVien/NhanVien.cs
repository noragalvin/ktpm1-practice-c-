using BULs;
using DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanVien
{
    public partial class NhanVien : Form
    {
        static NhanVienBUL myNhanVienBUL = new NhanVienBUL();
        
        int currentPageIndex = 1;
        int pageSize = 5; //Số dòng hiển thị lên lưới
        int pageNumber = 0; //Số trang
        int firstRow, lastRow; //Dòng bắt đầu, dòng kết thúc cho việc truy vấn dữ liệu
        int rows; //Số dòng được trả về từ câu truy vấn trong formLoad

        public NhanVien()
        {
            InitializeComponent();
        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            HienThiDuLieu();
        }

        public void HienThiDuLieu()
        {
            bool isSearch = cbSearch.Checked;
            string ten = txtSearch.Text;
            this.rows = Convert.ToInt32(myNhanVienBUL.NumberOfRecords(isSearch, ten));
            pageTotal();
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThemNhanVien them = new ThemNhanVien();
            them.Show();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            //dgv.DataSource = myNhanVienBUL.TimNhanVien(txtSearch.Text);

            cbSort.Checked = false;
            cbSearch.Checked = true;
            HienThiDuLieu();

        }

        void pageTotal()
        {
            try
            {
                this.pageNumber = this.rows % this.pageSize != 0 ? this.rows / this.pageSize + 1 : this.rows / this.pageSize;
                lbCurrentPage.Text = this.currentPageIndex.ToString();
                lbTotalPage.Text = pageNumber.ToString();
                cmbPage.Items.Clear();
                for (int i = 1; i <= this.pageNumber; i++)
                {
                    cmbPage.Items.Add(i + "");
                }
                cmbPage.SelectedIndex = 0;
            }
            catch (IndexOutOfRangeException iore)
            {
                MessageBox.Show("Không tìm thấy nhân viên");
            }
            catch (ArgumentOutOfRangeException aore)
            {
                MessageBox.Show("Không tìm thấy nhân viên");
            }
            
        }

        private void cmbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.currentPageIndex = Convert.ToInt32(cmbPage.SelectedItem.ToString());
            lbCurrentPage.Text = this.currentPageIndex.ToString();
            this.firstRow = this.pageSize * (this.currentPageIndex - 1); //Dong dau
            this.lastRow = this.pageSize * (this.currentPageIndex);//Dong cuoi cua 1 trang duoc chon.
            //MessageBox.Show(fistRow + " " + lastRow);
            bool isSort = cbSort.Checked;
            bool isSearch = cbSearch.Checked;
            string ten = txtSearch.Text;
            DataSet ds = new DataSet();
            myNhanVienBUL.CurrentRecords(isSort, isSearch, ten, ds,firstRow, pageSize);
            var empList = ds.Tables[0].AsEnumerable().Select(dataRow => new NhanVienDTO {
                ID = dataRow.Field<int>("ID"),
                HoTen = dataRow.Field<string>("HoTen"),
                Khoa_PhongBan = dataRow.Field<string>("Khoa_PhongBan"),
                TrinhDo_ChucVu = dataRow.Field<int>("TrinhDo_ChucVu"),
                PhuCap = dataRow.Field<int>("PhuCap"),
                SoTietDay_SoNgayCong = dataRow.Field<int>("SoTietDay_SoNgayCong"),
                HeSoLuong = (float)dataRow.Field<double>("HeSoLuong"),
                TongLuong = (float)dataRow.Field<double>("TongLuong"),
                LoaiNhanVien = dataRow.Field<int>("LoaiNhanVien"),

            }).ToList();

            List<NhanVienDTO> list = empList;
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(string));
            dt.Columns.Add("Họ tên", typeof(string));
            dt.Columns.Add("Khoa - Phòng ban", typeof(string));
            dt.Columns.Add("Trình độ - Chức vụ", typeof(string));
            dt.Columns.Add("Phụ cấp", typeof(int));
            dt.Columns.Add("Số tiết dạy - Số ngày công", typeof(int));
            dt.Columns.Add("Tổng lương", typeof(float));
            foreach (NhanVienDTO item in list)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = item.ID;
                dr["Họ tên"] = item.HoTen;
                dr["Khoa - Phòng ban"] = item.Khoa_PhongBan;
                dr["Trình độ - Chức vụ"] = convertTrinhDo(item.LoaiNhanVien.ToString(), item.TrinhDo_ChucVu.ToString());
                dr["Phụ cấp"] = item.PhuCap;
                dr["Số tiết dạy - Số ngày công"] = item.SoTietDay_SoNgayCong;
                dr["Tổng lương"] = item.TongLuong;
                dt.Rows.Add(dr);
            }

            dgv.DataSource = dt;

        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            //dgv.DataSource = myNhanVienBUL.SapXep();
            /*
            dgv.Columns[0].HeaderText = "ID";
            dgv.Columns[1].HeaderText = "Họ tên";
            dgv.Columns[2].HeaderText = "Khoa - Phòng ban";
            dgv.Columns[3].HeaderText = "Trình độ - Chức vụ";
            dgv.Columns[4].HeaderText = "Phụ cấp";
            dgv.Columns[5].HeaderText = "Số tiết dạy/Ngày công";
            dgv.Columns[7].HeaderText = "Tổng lương";
            dgv.Columns[6].Visible = false;
            dgv.Columns[8].Visible = false;*/
            cbSort.Checked = true;
            cbSearch.Checked = false;
            HienThiDuLieu();
        }

        public string convertTrinhDo(string loai, string trinhdo)
        {
            if (loai == "1")
            {
                if (trinhdo == "1")
                    return "Cử nhân";
                if (trinhdo == "2")
                    return "Thạc sĩ";
                if (trinhdo == "3")
                    return "Tiến sĩ";
            }
            if (loai == "0")
            {
                if (trinhdo == "1")
                    return "Trưởng phòng";
                if (trinhdo == "2")
                    return "Phó phòng";
                if (trinhdo == "3")
                    return "Nhân viên";
            }
            return "";
        }

    }
}
