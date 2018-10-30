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
    public partial class ThemNhanVien : Form
    {
        NhanVienBUL myNhanVienBUL = new NhanVienBUL();

        public ThemNhanVien()
        {
            InitializeComponent();
            cbNV.Visible = false;
            cbLoai.SelectedIndex = 0;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ten = txtTen.Text;
            string khoa = txtKhoa.Text;
            int hsl = Convert.ToInt32(txtHSL.Text);
            int sotietday = Convert.ToInt32(txtSoTietDay.Text);
            int td;
            float tl;
            int loai;
            int phucap = Convert.ToInt32(txtPhuCap.Text);
            if (cbLoai.SelectedIndex == 0)
            {
                loai = 1;
                string selectedComboBoxString = cbGV.SelectedItem.ToString();
                td = convertTrinhDo(selectedComboBoxString);
                tl = hsl * 730 + phucap + sotietday * 45;
            }
            else
            {
                loai = 0;
                string selectedComboBoxString = cbNV.SelectedItem.ToString();
                td = convertTrinhDo(selectedComboBoxString);
                tl = hsl * 730 + phucap + sotietday * 30;
            }

            
            NhanVienDTO aNV = new NhanVienDTO(ten, khoa, td, phucap, sotietday, hsl, tl, loai);

            myNhanVienBUL.ThemMotNhanVien(aNV);
            this.Hide();
            NhanVien nv = new NhanVien();
            nv.Show();
        }

        private void ThemNhanVien_Load(object sender, EventArgs e)
        {
            cbGV.SelectedIndex = 0;
            cbNV.SelectedIndex = 0;
        }

        public int convertTrinhDo(string str)
        {
            if (str == "Cử nhân" || str == "Trưởng phòng")
                return 1;
            if (str == "Thạc sĩ" || str == "Phó phòng")
                return 2;
            if (str == "Tiến sĩ" || str == "Nhân viên")
                return 3;
            return 0;
        }

        public int convertPhuCap(string str)
        {
            if (str == "Cử nhân")
                return 300;
            if (str == "Trưởng phòng")
                return 2000;
            if (str == "Thạc sĩ")
                return 500;
            if (str == "Phó phòng")
                return 1000;
            if (str == "Tiến sĩ")
                return 1000;
            if (str == "Nhân viên")
                return 500;
            return 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            NhanVien nv = new NhanVien();
            nv.Show();
        }

        private void cbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLoai.SelectedIndex == 0)
            {
                cbGV.Visible = true;
                cbNV.Visible = false;
                cbGV.SelectedIndex = 0;
                txtPhuCap.Text = (convertPhuCap(cbGV.SelectedItem.ToString())).ToString();
            }
            if (cbLoai.SelectedIndex == 1)
            {
                cbGV.Visible = false;
                cbNV.Visible = true;
                cbNV.SelectedIndex = 0;
                txtPhuCap.Text = (convertPhuCap(cbNV.SelectedItem.ToString())).ToString();
            }
        }

        private void cbGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLoai.SelectedItem.ToString() == "Giảng viên")
            {
                txtPhuCap.Text = convertPhuCap(cbGV.SelectedItem.ToString()).ToString();
            }
        }

        private void cbNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLoai.SelectedItem.ToString() == "Nhân viên hành chính")
            {
                txtPhuCap.Text = convertPhuCap(cbNV.SelectedItem.ToString()).ToString();
            }
        }




        
    }
}
