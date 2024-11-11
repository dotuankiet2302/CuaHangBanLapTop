using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace App_BanLaptop.Forms
{
    public partial class QL_KhachHang : Form
    {
        KhachHangBLL bllKhachHang = new KhachHangBLL();
        public QL_KhachHang()
        {
            InitializeComponent();
            this.Load += QL_KhachHang_Load;
            this.dgvKH.CellClick += DgvKH_CellClick;
            this.Them.Click += Them_Click;
            this.Sua.Click += Sua_Click;
            this.Xoa.Click += Xoa_Click;
        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            int maKhachHang = int.Parse(txtManv.Text); // Lấy mã môn học từ textbox

            if (bllKhachHang.XoaKhachHang(maKhachHang))
            {
                MessageBox.Show("Xóa Thành Công");
                loadKhachHang(); // Gọi hàm load lại danh sách môn học
            }
            else
            {
                MessageBox.Show("Xóa Thất bại");
                //// Kiểm tra xem mã không tồn tại hay có điểm liên quan
                //var hasScores = bllKhachHang.KiemTraDiemMon(maKhachHang);
                //if (hasScores)
                //{
                //    MessageBox.Show("Không thể xóa. Môn học này đã có điểm liên quan.");
                //}
                //else
                //{
                //    MessageBox.Show("Mã môn học '" + maKhachHang + "' không tồn tại. Không thể xóa.");
                //}
            }
        }

        private void Sua_Click(object sender, EventArgs e)
        {
            string sex = radioButtonNam.Checked ? "NAM" : "NỮ";
            khachhang dt = new khachhang();
            dt.MAKH = int.Parse(txtManv.Text);
            dt.HOTEN = txtTennv.Text;
            dt.NGAYSINH = DateTime.Parse(txtNgaySinh.Text);
            dt.GIOITINH = sex;
            dt.DIENTHOAI = txtPhone.Text;
            dt.TAIKHOAN = txtUserName.Text;
            dt.MATKHAU = txtPass.Text;
            dt.EMAIL = txtEmail.Text;
            dt.DIACHI = txtAddress.Text;
            dt.MAQUYEN = int.Parse(txtMaQuyen.Text);
            dt.MATINH = int.Parse(txtMaTinh.Text);

            if (bllKhachHang.SuaKhachHang(dt))
            {
                MessageBox.Show("Sửa Thành Công");
                loadKhachHang();
            }
            else
            {
                MessageBox.Show("Sửa Thất Bại");
            }
        }

        private void Them_Click(object sender, EventArgs e)
        {
            string sex = radioButtonNam.Checked ? "NAM" : "NỮ";
            khachhang dt = new khachhang();
            dt.MAKH = int.Parse(txtManv.Text);
            dt.HOTEN = txtTennv.Text;
            dt.NGAYSINH = DateTime.Parse(txtNgaySinh.Text);
            dt.GIOITINH = sex;
            dt.DIENTHOAI = txtPhone.Text;
            dt.TAIKHOAN = txtUserName.Text;
            dt.MATKHAU = txtPass.Text;
            dt.EMAIL = txtEmail.Text;
            dt.DIACHI = txtAddress.Text;
            dt.MAQUYEN = int.Parse(txtMaQuyen.Text);
            dt.MATINH = int.Parse(txtMaTinh.Text);

            if (bllKhachHang.ThemKhachHang(dt))
            {
                MessageBox.Show("Thanh Cong");
                loadKhachHang();
            }
            else
            {
                MessageBox.Show("That Bai");
            }
        }

        private void DgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKH.Rows[e.RowIndex];

                txtManv.Text = row.Cells["MAKH"].Value.ToString();
                txtTennv.Text = row.Cells["HOTEN"].Value.ToString();
                txtNgaySinh.Text = row.Cells["NGAYSINH"].Value.ToString();
                if (row.Cells["GIOITINH"].Value.ToString() == "NAM")
                    radioButtonNu.Checked = row.Cells["GIOITINH"].Value.ToString() == "NAM";
                else if (row.Cells["GIOITINH"].Value.ToString() == "NỮ")
                    radioButtonNam.Checked = row.Cells["GIOITINH"].Value.ToString() == "NỮ";

                txtPhone.Text = row.Cells["DIENTHOAI"].Value.ToString();
                txtUserName.Text = row.Cells["TAIKHOAN"].Value.ToString();
                txtPass.Text = row.Cells["MATKHAU"].Value.ToString();
                txtEmail.Text = row.Cells["EMAIL"].Value.ToString();
                txtAddress.Text = row.Cells["DIACHI"].Value.ToString();
                txtMaQuyen.Text = row.Cells["MAQUYEN"].Value.ToString();
                txtMaTinh.Text = row.Cells["MATINH"].Value.ToString();
            }
        }

        public void loadKhachHang()
        {
            dgvKH.DataSource = bllKhachHang.GetKhachHang();
        }
        private void QL_KhachHang_Load(object sender, EventArgs e)
        {
            loadKhachHang();
        }
    }
}
