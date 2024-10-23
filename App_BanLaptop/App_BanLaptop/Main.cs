using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_BanLaptop
{
    public partial class Main : Form
    {
        private Form activateForm;
        public Main()
        {
            InitializeComponent();
        }
        private void openChildForm(Form childForm, Object btnSender)
        {
            if (activateForm != null)
            {
                activateForm.Close();
            }
            // ActivateButton(btnSender);
            activateForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(childForm);
            this.panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            TopLabel.Text = "Nhân Viên";
            openChildForm(new Forms.QL_NhanVien(), sender);
        }

        private void picNhanVien_Click(object sender, EventArgs e)
        {
            TopLabel.Text = "Nhân Viên";
            openChildForm(new Forms.QL_NhanVien(), sender);
        }

        private void btnQuanAo_Click(object sender, EventArgs e)
        {
            TopLabel.Text = "Sản Phẩm";
            openChildForm(new Forms.QL_SanPham(), sender);
        }

        private void picQuanAo_Click(object sender, EventArgs e)
        {
            TopLabel.Text = "Sản Phẩm";
            openChildForm(new Forms.QL_SanPham(), sender);
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            TopLabel.Text = "Hóa Đơn";
            openChildForm(new Forms.HoaDon(), sender);
        }

        private void picHoaDon_Click(object sender, EventArgs e)
        {
            TopLabel.Text = "Hóa Đơn";
            openChildForm(new Forms.HoaDon(), sender);
        }

        private void btnTTKhachHang_Click(object sender, EventArgs e)
        {
            TopLabel.Text = "Khách Hàng";
            openChildForm(new Forms.QL_KhachHang(), sender);
        }

        private void picTTKH_Click(object sender, EventArgs e)
        {
            TopLabel.Text = "Khách Hàng";
            openChildForm(new Forms.QL_KhachHang(), sender);
        }

        private void btnDatHang_Click(object sender, EventArgs e)
        {
            TopLabel.Text = "Đặt Hàng";
            openChildForm(new Forms.DatHang(), sender);
        }

        private void picDatHang_Click(object sender, EventArgs e)
        {
            TopLabel.Text = "Đặt Hàng";
            openChildForm(new Forms.DatHang(), sender);
        }

        private void btnTKDoanhThu_Click(object sender, EventArgs e)
        {
            TopLabel.Text = "Báo cáo thống kê";
            openChildForm(new Forms.BaoCaoThongKe(), sender);
        }

        private void picTKDT_Click(object sender, EventArgs e)
        {
            TopLabel.Text = "Báo cáo thống kê";
            openChildForm(new Forms.BaoCaoThongKe(), sender);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.loginForm.Show();
        }
    }
}
