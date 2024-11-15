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

                txtMaMH.Text = row.Cells["MALAP"].Value.ToString();
                txtTenMH.Text = row.Cells["TENLAP"].Value.ToString();
                txtMaTinhTrang.Text = row.Cells["MATINHTRANG"].Value.ToString();
                txtGiaBan.Text = row.Cells["GIABAN"].Value.ToString();
                txtMoTa.Text = row.Cells["MOTA"].Value.ToString();
                txtNgayCapNhat.Text = row.Cells["NGAYCAPNHAT"].Value.ToString();
                picAnhBia.Text = row.Cells["ANHBIA"].Value.ToString();
                if (e.RowIndex >= 0 && e.ColumnIndex == dgvSanPham.Columns["ANHBIA"].Index)

                {
                    string duongDanAnh = dgvSanPham.Rows[e.RowIndex].Cells["ANHBIA"].Value.ToString();
                    try
                    {
                        picAnhBia.Image = Image.FromFile(duongDanAnh);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi load hình ảnh: " + ex.Message);
                    }
                }
                nUDSoLuong.Text = row.Cells["SOLUONGTON"].Value.ToString();
                txtMaHang.Text = row.Cells["MAHANG"].Value.ToString();
                txtMaNSX.Text = row.Cells["MANSX"].Value.ToString();
            }
        }

        public void loadLaptop()
        {
            var danhSachSanPhamViewModel = bllLaptop.GetLaptop();
            dgvSanPham.DataSource = danhSachSanPhamViewModel;
            //dgvSanPham.DataSource = bllLaptop.GetLaptop();
        }
        private void QL_SanPham_Load(object sender, EventArgs e)
        {
            loadLaptop();
        }
    }
}
