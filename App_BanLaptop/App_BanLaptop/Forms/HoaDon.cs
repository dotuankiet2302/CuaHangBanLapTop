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
    public partial class HoaDon : Form
    {
        DonHangBLL bllDonHang = new DonHangBLL();
        public HoaDon()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Load += HoaDon_Load;
            this.dgvHD.CellClick += DgvHD_CellClick;
            this.Them.Click += Them_Click;
            this.Sua.Click += Sua_Click;
            this.Xoa.Click += Xoa_Click;
            btnTimKiem.Click += BtnTimKiem_Click;
            txtTimKiem.TextChanged += TxtTimKiem_TextChanged;
            this.In.Click += In_Click;
        }

        private void In_Click(object sender, EventArgs e)
        {
            if (dgvHD.Rows.Count > 0)
            {
                string maHD = txtMaDH.Text;
                string ngayDat = txtNgayDat.Text;
                string ngayGiao = txtNgayGiao.Text;
                if (maHD == "" || ngayDat == "" || ngayGiao == "")
                {
                    MessageBox.Show("Hãy chọn 1 hàng trước.");
                    return;
                }

                WordExport dt = new WordExport();
                dt.HoaDon(maHD, ngayDat, ngayGiao);
            }
            else
            {
                MessageBox.Show("Hãy chọn 1 hàng trước.");
            }
        }

        private void TxtTimKiem_TextChanged(object sender, EventArgs e)
        {
            if (cboTimKiem.Text == "Mã Đơn Hàng")
            {
                string keyword = txtTimKiem.Text;
                dgvHD.DataSource = bllDonHang.TimKiemDonHang(keyword);
            }
            else if (cboTimKiem.Text == "Ngày Đặt")
            {
                DateTime keyword;
                if (DateTime.TryParse(txtTimKiem.Text, out keyword))
                {
                    dgvHD.DataSource = bllDonHang.TimKiemQuaNgayDat(keyword);
                }
                else
                {
                    // Xử lý trường hợp nhập liệu không hợp lệ, ví dụ: hiển thị thông báo lỗi
                    LoadDonHang();
                    //MessageBox.Show("Ngày đặt không hợp lệ. Vui lòng nhập lại.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            if (cboTimKiem.Text == "Mã Đơn Hàng")
            {
                string keyword = txtTimKiem.Text;
                dgvHD.DataSource = bllDonHang.TimKiemDonHang(keyword);
            }
            else if (cboTimKiem.Text == "Ngày Đặt")
            {
                DateTime keyword;
                if (DateTime.TryParse(txtTimKiem.Text, out keyword))
                {
                    dgvHD.DataSource = bllDonHang.TimKiemQuaNgayDat(keyword);
                }
                else
                {
                    // Xử lý trường hợp nhập liệu không hợp lệ, ví dụ: hiển thị thông báo lỗi
                    LoadDonHang();
                    //MessageBox.Show("Ngày đặt không hợp lệ. Vui lòng nhập lại.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            int maDonhang = int.Parse(txtMaDH.Text); // Lấy mã môn học từ textbox

            if (bllDonHang.XoaDonHang(maDonhang))
            {
                MessageBox.Show("Xóa Thành Công");
                LoadDonHang(); // Gọi hàm load lại danh sách môn học
            }
            else
            {
                MessageBox.Show("Xóa Thất bại");
                //// Kiểm tra xem mã không tồn tại hay có điểm liên quan
                //var hasScores = bllNhanVien.KiemTraDiemMon(maNhanVien);
                //if (hasScores)
                //{
                //    MessageBox.Show("Không thể xóa. Môn học này đã có điểm liên quan.");
                //}
                //else
                //{
                //    MessageBox.Show("Mã môn học '" + maNhanVien + "' không tồn tại. Không thể xóa.");
                //}
            }
        }

        private void Sua_Click(object sender, EventArgs e)
        {
            donhang dt = new donhang();
            dt.MADH = int.Parse(txtMaDH.Text);
            dt.NGAYGIAO = DateTime.Parse(txtNgayGiao.Text);
            dt.NGAYDAT = DateTime.Parse(txtNgayDat.Text);
            dt.DATHANHTOAN = txtThanhToan.Text;
            dt.TINHTRANGGIAO = txtTTGiao.Text;
            dt.MAKH = int.Parse(txtMaKH.Text);

            if (bllDonHang.SuaDonHang(dt))
            {
                MessageBox.Show("Sửa Thành Công");
                LoadDonHang();
            }
            else
            {
                MessageBox.Show("Sửa Thất Bại");
            }
        }

        private void Them_Click(object sender, EventArgs e)
        {
            donhang dt = new donhang();
            dt.MADH = int.Parse(txtMaDH.Text);
            dt.NGAYGIAO = DateTime.Parse(txtNgayGiao.Text);
            dt.NGAYDAT = DateTime.Parse(txtNgayDat.Text);
            dt.DATHANHTOAN = txtThanhToan.Text;
            dt.TINHTRANGGIAO = txtTTGiao.Text;
            dt.MAKH = int.Parse(txtMaKH.Text);

            if (bllDonHang.ThemDonHang(dt))
            {
                MessageBox.Show("Thanh Cong");
                LoadDonHang();
            }
            else
            {
                MessageBox.Show("That Bai");
            }
        }

        private void DgvHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHD.Rows[e.RowIndex];

                txtMaDH.Text = row.Cells["MADH"].Value.ToString();
                txtNgayGiao.Text = row.Cells["NGAYGIAO"].Value.ToString();
                txtNgayDat.Text = row.Cells["NGAYDAT"].Value.ToString();
                txtThanhToan.Text = row.Cells["DATHANHTOAN"].Value.ToString();
                txtTTGiao.Text = row.Cells["TINHTRANGGIAO"].Value.ToString();
                txtMaKH.Text = row.Cells["MAKH"].Value.ToString();
            }
        }

        public void LoadDonHang()
        {
            var danhSachDonHangViewModel = bllDonHang.GetDonHang();
            dgvHD.DataSource = danhSachDonHangViewModel;
            //dgvHD.DataSource = bllDonHang.GetDonHang();
        }
        private void HoaDon_Load(object sender, EventArgs e)
        {
            LoadDonHang();
        }
    }
}
