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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace App_BanLaptop.Forms
{
    public partial class QL_SanPham : Form
    {
        LaptopBLL bllLaptop = new LaptopBLL();
        public QL_SanPham()
        {
            InitializeComponent();
            this.Load += QL_SanPham_Load;
            this.dgvSanPham.CellClick += DgvSanPham_CellClick;
            this.Them.Click += Them_Click;
            this.Xoa.Click += Xoa_Click;
            this.Sua.Click += Sua_Click;
            btnTimKiem.Click += BtnTimKiem_Click;
            txtTimKiem.TextChanged += TxtTimKiem_TextChanged;
        }

        private void TxtTimKiem_TextChanged(object sender, EventArgs e)
        {
            //string keyword = txtTimKiem.Text;
            //var products = bllLaptop.SearchProducts(keyword);

            //BindingSource bindingSource = new BindingSource();
            //bindingSource.DataSource = products;

            //dgvSanPham.DataSource = bindingSource;

            //dgvSanPham.Columns["hangmay"].Visible = false;
            //dgvSanPham.Columns["nhasx"].Visible = false;
            //dgvSanPham.Columns["tinhtrangmay"].Visible = false;
            if (cboTimKiem.Text == "Tên Sản Phẩm")
            {
                string keyword = txtTimKiem.Text;
                dgvSanPham.DataSource = bllLaptop.SearchProducts(keyword);
            }
            else if (cboTimKiem.Text == "Giá Bán")
            {
                decimal keyword;
                if (decimal.TryParse(txtTimKiem.Text, out keyword))
                {
                    dgvSanPham.DataSource = bllLaptop.SearchProductsByPrice(keyword);
                }
                else
                {
                    // Xử lý trường hợp nhập liệu không hợp lệ, ví dụ: hiển thị thông báo lỗi
                    MessageBox.Show("Giá bán không hợp lệ. Vui lòng nhập lại.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            if (cboTimKiem.Text == "Tên Sản Phẩm")
            {
                string keyword = txtTimKiem.Text;
                dgvSanPham.DataSource = bllLaptop.SearchProducts(keyword);
            }
            else if (cboTimKiem.Text == "Giá Bán")
            {
                decimal keyword;
                if (decimal.TryParse(txtTimKiem.Text, out keyword))
                {
                    dgvSanPham.DataSource = bllLaptop.SearchProductsByPrice(keyword);
                }
                else
                {
                    // Xử lý trường hợp nhập liệu không hợp lệ, ví dụ: hiển thị thông báo lỗi
                    MessageBox.Show("Giá bán không hợp lệ. Vui lòng nhập lại.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Sua_Click(object sender, EventArgs e)
        {
            laptop dt = new laptop();
            dt.MALAP = int.Parse(txtMaMH.Text);
            dt.TENLAP = txtTenMH.Text;
            dt.MATINHTRANG = int.Parse(txtMaTinhTrang.Text);
            dt.GIABAN = decimal.Parse(txtGiaBan.ToString());
            dt.MOTA = txtMoTa.Text;
            dt.NGAYCAPNHAT = DateTime.Parse(txtNgayCapNhat.Text);
            dt.ANHBIA = picAnhBia.Text;
            dt.SOLUONGTON = int.Parse(nUDSoLuong.Text);
            dt.MAHANG = int.Parse(txtMaHang.Text);
            dt.MANSX = int.Parse(txtMaNSX.Text);

            if (bllLaptop.SuaLaptop(dt))
            {
                MessageBox.Show("Sửa Thành Công");
                loadLaptop();
            }
            else
            {
                MessageBox.Show("Sửa Thất Bại");
            }
        }

        private void Xoa_Click(object sender, EventArgs e)
        {
            int maNhanVien = int.Parse(txtMaMH.Text); // Lấy mã môn học từ textbox

            if (bllLaptop.XoaLaptop(maNhanVien))
            {
                MessageBox.Show("Xóa Thành Công");
                loadLaptop(); // Gọi hàm load lại danh sách môn học
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

        private void Them_Click(object sender, EventArgs e)
        {
            laptop dt = new laptop();
            dt.MALAP = int.Parse(txtMaMH.Text);
            dt.TENLAP = txtTenMH.Text;
            dt.MATINHTRANG = int.Parse(txtMaTinhTrang.Text);
            dt.GIABAN = decimal.Parse(txtGiaBan.ToString());
            dt.MOTA = txtMoTa.Text;
            dt.NGAYCAPNHAT = DateTime.Parse(txtNgayCapNhat.Text);
            dt.ANHBIA = picAnhBia.Text;
            dt.SOLUONGTON = int.Parse(nUDSoLuong.Text);
            dt.MAHANG = int.Parse(txtMaHang.Text);
            dt.MANSX = int.Parse(txtMaNSX.Text);

            if (bllLaptop.ThemLaptop(dt))
            {
                MessageBox.Show("Thanh Cong");
                loadLaptop();
            }
            else
            {
                MessageBox.Show("That Bai");
            }
        }

        private void DgvSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSanPham.Rows[e.RowIndex];

                string images = row.Cells["ANHBIA"].Value.ToString();
                txtMaMH.Text = row.Cells["MALAP"].Value.ToString();
                txtTenMH.Text = row.Cells["TENLAP"].Value.ToString();
                txtMaTinhTrang.Text = row.Cells["MATINHTRANG"].Value.ToString();
                txtGiaBan.Text = row.Cells["GIABAN"].Value.ToString();
                txtMoTa.Text = row.Cells["MOTA"].Value.ToString();
                txtNgayCapNhat.Text = row.Cells["NGAYCAPNHAT"].Value.ToString();
                nUDSoLuong.Text = row.Cells["SOLUONGTON"].Value.ToString();
                txtMaHang.Text = row.Cells["MAHANG"].Value.ToString();
                txtMaNSX.Text = row.Cells["MANSX"].Value.ToString();

                try
                {
                    picAnhBia.Image = new Bitmap(Application.StartupPath + "\\Images\\" + images);
                }
                catch (ArgumentException ex)
                {
                    // Handle the exception, e.g., display an error message or set a default image
                    MessageBox.Show("Chưa có ảnh cho dòng sản phẩm này!!!\n" + ex.Message);
                    picAnhBia.Image = new Bitmap(Application.StartupPath + "\\Images\\errorImage.jpg");
                }
            }
        }

        public void loadLaptop()
        {
            dgvSanPham.DataSource = bllLaptop.GetLaptop();
        }
        private void QL_SanPham_Load(object sender, EventArgs e)
        {
            loadLaptop();
        }
    }
}
