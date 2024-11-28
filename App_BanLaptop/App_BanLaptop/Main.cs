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
        private Form activeForm = null;
        public Main()
        {
            InitializeComponent();
            //this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.Resize += new EventHandler(Main_Resize);
            this.btnNhanVien.Click += BtnNhanVien_Click;
            this.picNhanVien.Click += PicNhanVien_Click;
            this.btnSanPham.Click += BtnSanPham_Click;
            this.picSanPham.Click += PicSanPham_Click;
            this.btnHoaDon.Click += BtnHoaDon_Click;
            this.picHoaDon.Click += PicHoaDon_Click;
            this.btnTTKhachHang.Click += BtnTTKhachHang_Click;
            this.picTTKH.Click += PicTTKH_Click;
            this.btnTinTuc.Click += BtnDatHang_Click;
            this.picTinTuc.Click += PicDatHang_Click;
            this.btnTKDoanhThu.Click += BtnTKDoanhThu_Click;
            this.picTKDT.Click += PicTKDT_Click;
            this.btnDangXuat.Click += BtnDangXuat_Click;
            this.picDangXuat.Click += PicDangXuat_Click;
        }

        private void PicDangXuat_Click(object sender, EventArgs e)
        {
            BtnDangXuat_Click(sender, e);
        }

        private void BtnDangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PicTKDT_Click(object sender, EventArgs e)
        {
            BtnTKDoanhThu_Click(sender, e);
        }

        private void BtnTKDoanhThu_Click(object sender, EventArgs e)
        {
            TopLabel.Text = "Báo cáo thống kê";
            openChildForm(new Forms.BaoCaoThongKe());
        }

        private void BtnDatHang_Click(object sender, EventArgs e)
        {
            TopLabel.Text = "Đặt Hàng";
            openChildForm(new Forms.TinTuc());
        }

        private void PicDatHang_Click(object sender, EventArgs e)
        {
            BtnDatHang_Click(sender, e);
        }

        private void PicTTKH_Click(object sender, EventArgs e)
        {
            BtnTTKhachHang_Click(sender, e);
        }

        private void BtnTTKhachHang_Click(object sender, EventArgs e)
        {
            TopLabel.Text = "Khách Hàng";
            openChildForm(new Forms.QL_KhachHang());
        }

        private void PicHoaDon_Click(object sender, EventArgs e)
        {
            BtnHoaDon_Click(sender, e);
        }

        private void BtnHoaDon_Click(object sender, EventArgs e)
        {
            TopLabel.Text = "Đơn Hàng";
            openChildForm(new Forms.HoaDon());
        }

        private void PicSanPham_Click(object sender, EventArgs e)
        {
            BtnSanPham_Click(sender, e);
        }

        private void BtnSanPham_Click(object sender, EventArgs e)
        {
            TopLabel.Text = "Laptop";
            openChildForm(new Forms.QL_SanPham());
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            panel1.Width = this.ClientSize.Width - panelMenu.Width;
            panel1.Height = this.ClientSize.Height;
        }

        private void PicNhanVien_Click(object sender, EventArgs e)
        {
            BtnNhanVien_Click(sender, e);
        }

        private void BtnNhanVien_Click(object sender, EventArgs e)
        {
            TopLabel.Text = "Nhân Viên";
            openChildForm(new Forms.QL_NhanVien());
        }

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            childForm.AutoScaleMode = AutoScaleMode.Dpi;
            panel1.Controls.Add(childForm);
            panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.loginForm.Show();
        }
    }
    //[System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
    //private static extern IntPtr CreateRoundRectRgn
    //(
    //    int nLeftRect,
    //    int nTopRect,
    //    int nRightRect,
    //    int nBottomRect,
    //    int nWidthEllipse,
    //    int nHeightEllipse
    //);
}
