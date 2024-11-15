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
using App_BanLaptop.doan_laptopTableAdapters;
using System.Data.SqlClient;

namespace App_BanLaptop.Forms
{
    public partial class QL_KhachHang : Form
    {
        KhachHangBLL bllKhachHang = new KhachHangBLL();
        public QL_KhachHang()
        {
            InitializeComponent();
            this.txtMakh.Enabled = false;
            this.Load += QL_KhachHang_Load;
            this.dgvKH.CellClick += DgvKH_CellClick;
            this.Them.Click += Them_Click;
            this.Sua.Click += Sua_Click;
            this.Xoa.Click += Xoa_Click;
            cbHienThiMK.CheckedChanged += CbHienThiMK_CheckedChanged;
            this.dgvKH.CellFormatting += DgvKH_CellFormatting;
            this.btnSearch.Click += BtnSearch_Click;
            txtTimKiem.TextChanged += TxtTimKiem_TextChanged;
        }

        private void TxtTimKiem_TextChanged(object sender, EventArgs e)
        {
            QLKhachHangTableAdapter qlKH = new QLKhachHangTableAdapter();
            if (txtTimKiem.Text == "")
            {
                loadKhachHang();
            }
            else if (cboTimKiem.Text == "Mã Khách Hàng")
            {
                dgvKH.DataSource = qlKH.GetDataBy3(Convert.ToInt32(txtTimKiem.Text));
            }
            else if (cboTimKiem.Text == "Tên Khách Hàng")
            {
                dgvKH.DataSource = qlKH.GetDataBy4(txtTimKiem.Text);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            QLKhachHangTableAdapter qlKH = new QLKhachHangTableAdapter();
            if (txtTimKiem.Text == "")
            {
                loadKhachHang();
            }
            else if (cboTimKiem.Text == "Mã Khách Hàng")
            {
                dgvKH.DataSource = qlKH.GetDataBy3(Convert.ToInt32(txtTimKiem.Text));
            }else if(cboTimKiem.Text == "Tên Khách Hàng")
            {
                dgvKH.DataSource = qlKH.GetDataBy4(txtTimKiem.Text);
            }
        }

        private void DgvKH_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvKH.Columns[e.ColumnIndex].DataPropertyName == "MATKHAU" && e.Value != null)
            {
                e.Value = new string('*', e.Value.ToString().Length);
            }
        }

        private void CbHienThiMK_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienThiMK.Checked)
            {
                txtPass.PasswordChar = '\0';
            }
            else
            {
                txtPass.PasswordChar = '*';
            }
        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            int maKH = Convert.ToInt32(txtMakh.Text);
            QLKhachHangTableAdapter qlKH = new QLKhachHangTableAdapter();

            var existingRecord = qlKH.GetData().FirstOrDefault(kh => kh.MAKH == maKH);
            if (existingRecord != null)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    qlKH.Xoa(maKH);
                    MessageBox.Show("Xóa thành công");

                    loadKhachHang();
                }
            }
            else
            {
                MessageBox.Show("Mã Khách Hàng không tồn tại. Vui lòng kiểm tra lại.");
            }

        }

        private void Sua_Click(object sender, EventArgs e)
        {
            string gender = radioButtonNam.Checked ? "NAM" : "NỮ";
            QLKhachHangTableAdapter qlKH = new QLKhachHangTableAdapter();
            int MaKH = Convert.ToInt32(txtMakh.Text);
            string HoTen = txtTenkh.Text;
            string NgaySinh = txtNgaySinh.Text;
            string GioiTinh = gender;
            string DienThoai = txtPhone.Text;
            string TaiKhoan = txtUserName.Text;
            string MatKhau = txtPass.Text;
            string Email = txtEmail.Text;
            string DiaChi = txtAddress.Text;
            int MaTinh = Convert.ToInt32(txtMaTinh.Text);

            var existingRecord = qlKH.GetData().FirstOrDefault(kh => kh.MAKH == MaKH);
            if (existingRecord != null)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin khách hàng này không?", "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    qlKH.Sua(HoTen, NgaySinh, GioiTinh, DienThoai, TaiKhoan, MatKhau, Email, DiaChi, MaTinh, MaKH);
                    MessageBox.Show("Sửa thành công");
                    loadKhachHang();
                }
            }
            else
            {
                MessageBox.Show("Mã Khách Hàng không tồn tại. Vui lòng kiểm tra lại.");
            }

        }

        private void Them_Click(object sender, EventArgs e)
        {
            string gender = radioButtonNam.Checked ? "NAM" : "NỮ";
            QLKhachHangTableAdapter qlKH = new QLKhachHangTableAdapter();
            string HoTen = txtTenkh.Text;
            string NgaySinh = txtNgaySinh.Text;
            string GioiTinh = gender;
            string DienThoai = txtPhone.Text;
            string TaiKhoan = txtUserName.Text;
            string MatKhau = txtPass.Text;
            string Email = txtEmail.Text;
            string DiaChi = txtAddress.Text;
            //string MaQuyen = dgvKH.CurrentRow.Cells[9].Value.ToString(); 
            int MaTinh = Convert.ToInt32(txtMaTinh.Text);

            // Kiểm tra xem MaTinh đã tồn tại hay chưa
            var existingRecord = qlKH.GetData().FirstOrDefault(kh => kh.TAIKHOAN == TaiKhoan);
            if (existingRecord == null)
            {
                qlKH.Them(HoTen, NgaySinh, GioiTinh, DienThoai, TaiKhoan, MatKhau, Email, DiaChi, MaTinh);
                loadKhachHang();
                MessageBox.Show("Thành Công");
            }
            else
            {
                MessageBox.Show("Tên Tài Khoản đã tồn tại. Vui lòng chọn giá trị khác.");
            }
        }

        private void DgvKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvKH.Rows[e.RowIndex];

                txtMakh.Text = row.Cells[0].Value.ToString();
                txtTenkh.Text = row.Cells[1].Value.ToString();
                txtNgaySinh.Text = row.Cells[2].Value.ToString();
                if (row.Cells[3].Value.ToString() == "NAM")
                    radioButtonNam.Checked = row.Cells[3].Value.ToString() == "NAM";
                else if (row.Cells[3].Value.ToString() == "NỮ")
                    radioButtonNu.Checked = row.Cells[3].Value.ToString() == "NỮ";
                
                txtPhone.Text = row.Cells[4].Value.ToString();
                txtUserName.Text = row.Cells[5].Value.ToString();
                txtPass.Text = row.Cells[6].Value.ToString();
                txtEmail.Text = row.Cells[7].Value.ToString();
                txtAddress.Text = row.Cells[8].Value.ToString();
                txtMaTinh.Text = row.Cells[9].Value.ToString();

            }
        }

        public void loadKhachHang()
        {
            QLKhachHangTableAdapter qlKH = new QLKhachHangTableAdapter();
            DataTable dataTable = qlKH.GetData(); 
            dgvKH.DataSource = dataTable;
        }
        private void QL_KhachHang_Load(object sender, EventArgs e)
        {
            loadKhachHang();
        }

        private void khachhangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.khachhangBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.doan_laptop);

        }

        private void QL_KhachHang_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'doan_laptop.QLKhachHang' table. You can move, or remove it, as needed.
            this.qLKhachHangTableAdapter.Fill(this.doan_laptop.QLKhachHang);
            // TODO: This line of code loads data into the 'doan_laptop.khachhang' table. You can move, or remove it, as needed.
            this.khachhangTableAdapter.Fill(this.doan_laptop.khachhang);

        }
    }
}
