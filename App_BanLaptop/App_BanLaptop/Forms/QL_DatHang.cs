using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;

namespace App_BanLaptop.Forms
{
    public partial class QL_DatHang : Form
    {
        private readonly ID3RecommendationSystem recommendationSystem;
        private int maKhachHang;
        private DatHangBLL datHangBLL;
        private List<GioHangDTO> gioHang;

        public QL_DatHang(int maKH)
        {
            InitializeComponent();
            this.maKhachHang = maKH;
            InitializeCommonComponents();
            recommendationSystem = new ID3RecommendationSystem();
            this.dgvSPLienQuan.CellClick += DgvSPLienQuan_CellClick;
        }

        private void DgvSPLienQuan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvSPLienQuan.Rows[e.RowIndex];
                DisplayProductDetails(row);
            }
        }

        private void DisplayProductDetails(DataGridViewRow row)
        {
            txtMaMH.Text = row.Cells["MALAP"].Value.ToString();
            txtTenMH.Text = row.Cells["TENLAP"].Value.ToString();
            txtGiaBan.Text = row.Cells["GIABAN"].Value.ToString();
            // ... cập nhật các trường khác

            try
            {
                string images = row.Cells["ANHBIA"].Value.ToString();
                picAnhBia.Image = new Bitmap(Application.StartupPath + "\\Images\\" + images);
            }
            catch
            {
                picAnhBia.Image = new Bitmap(Application.StartupPath + "\\Images\\errorImage.jpg");
            }
        }
        // Phương thức khởi tạo chung
        private void InitializeCommonComponents()
        {
            datHangBLL = new DatHangBLL();
            gioHang = new List<GioHangDTO>();

            // Đăng ký các sự kiện
            this.Load += QL_DatHang_Load;
            this.dgvSanPham.CellClick += DgvSanPham_CellClick;
            btnDatHang.Click += BtnDatHang_Click;
            btnThemVaoGio.Click += BtnThemVaoGio_Click;
            btnXoaKhoiGio.Click += BtnXoaKhoiGio_Click;

            SetupGioHangColumns();
        }

        private void SetupGioHangColumns()
        {
            dgvGioHang.Columns.Add("MASP", "Mã SP");
            dgvGioHang.Columns.Add("TENSP", "Tên Sản Phẩm");
            dgvGioHang.Columns.Add("SOLUONG", "Số Lượng");
            dgvGioHang.Columns.Add("GIA", "Giá");
            dgvGioHang.Columns.Add("THANHTIEN", "Thành Tiền");
        }
        private void RefreshGioHang()
        {
            dgvGioHang.Rows.Clear();
            foreach (var item in gioHang)
            {
                dgvGioHang.Rows.Add(
                    item.MaSP,
                    item.TenSP,
                    item.SoLuong,
                    item.Gia,
                    item.ThanhTien
                );
            }
            // Cập nhật tổng tiền
            lblTongTien.Text = $"Tổng tiền: {gioHang.Sum(x => x.ThanhTien):N0} VNĐ";
        }

        private void BtnXoaKhoiGio_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.CurrentRow != null)
            {
                int maSP = int.Parse(dgvGioHang.CurrentRow.Cells["MASP"].Value.ToString());
                gioHang.RemoveAll(x => x.MaSP == maSP);
                RefreshGioHang();
            }
        }

        private void BtnThemVaoGio_Click(object sender, EventArgs e)
        {
            try
            {
                int maSP = int.Parse(txtMaMH.Text);
                string tenSP = txtTenMH.Text;
                int soLuong = (int)nUDSoLuong.Value;
                decimal gia = decimal.Parse(txtGiaBan.Text);

                // Kiểm tra số lượng tồn
                int soLuongTon = int.Parse(dgvSanPham.CurrentRow.Cells["SOLUONGTON"].Value.ToString());
                
                // Tính tổng số lượng trong giỏ hàng hiện tại
                int soLuongTrongGio = gioHang.Where(x => x.MaSP == maSP).Sum(x => x.SoLuong);
                
                if (soLuong + soLuongTrongGio > soLuongTon)
                {
                    MessageBox.Show($"Số lượng đặt ({soLuong + soLuongTrongGio}) vượt quá số lượng tồn ({soLuongTon})!", 
                                "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thêm vào giỏ hàng
                var existingItem = gioHang.FirstOrDefault(x => x.MaSP == maSP);
                if (existingItem != null)
                {
                    existingItem.SoLuong += soLuong;
                }
                else
                {
                    gioHang.Add(new GioHangDTO
                    {
                        MaSP = maSP,
                        TenSP = tenSP,
                        SoLuong = soLuong,
                        Gia = gia
                    });
                }

                RefreshGioHang();
                ClearInputs();
                MessageBox.Show("Đã thêm vào giỏ hàng!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm vào giỏ: " + ex.Message);
            }
        }
        private void ClearInputs()
        {
            txtMaMH.Text = "";
            txtTenMH.Text = "";
            nUDSoLuong.Value = 1;
            txtGiaBan.Text = "0";
            // Clear các textbox khác nếu có
        }

        private void BtnDatHang_Click(object sender, EventArgs e)
        {
            try
            {
                if (SessionManager.CurrentCustomerId == -1)
                {
                    MessageBox.Show("Vui lòng đăng nhập trước khi đặt hàng!",
                                  "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (gioHang.Count == 0)
                {
                    MessageBox.Show("Giỏ hàng trống!",
                                  "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                bool allSuccess = true;
                string errorMessage = "";

                foreach (var item in gioHang)
                {
                    try
                    {
                        if (!datHangBLL.ThemDonHang(SessionManager.CurrentCustomerId,
                            item.MaSP, item.SoLuong, item.Gia))
                        {
                            allSuccess = false;
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        errorMessage = ex.Message;
                        allSuccess = false;
                        break;
                    }
                }

                if (allSuccess)
                {
                    gioHang.Clear();
                    RefreshGioHang();
                    MessageBox.Show("Đặt hàng thành công!", "Thông báo",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvSanPham.DataSource = datHangBLL.GetAllSanPham(); // Refresh lại danh sách sản phẩm
                }
                else
                {
                    MessageBox.Show("Đặt hàng thất bại! " + errorMessage,
                                  "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message,
                               "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void LoadRecommendedProducts()
        {
            try
            {
                if (SessionManager.CurrentCustomerId != -1)
                {
                    var recommendationSystem = new ID3RecommendationSystem();
                    var purchaseHistory = datHangBLL.GetPurchaseHistory(SessionManager.CurrentCustomerId);
                    var recommendedProducts = recommendationSystem.GetRecommendations(
                        SessionManager.CurrentCustomerId,
                        purchaseHistory,
                        5 // Số lượng sản phẩm đề xuất
                    );

                    dgvSPLienQuan.DataSource = recommendedProducts;
                    FormatRecommendationGridView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải sản phẩm đề xuất: " + ex.Message);
            }
        }
        private void FormatRecommendationGridView()
        {
            if (dgvSPLienQuan.Columns.Count > 0)
            {
                dgvSPLienQuan.Columns["MALAP"].HeaderText = "Mã Laptop";
                dgvSPLienQuan.Columns["TENLAP"].HeaderText = "Tên Laptop";
                dgvSPLienQuan.Columns["GIABAN"].HeaderText = "Giá Bán";

                // Ẩn các cột không cần thiết
                var columnsToHide = new[] { "MOTA", "MATINHTRANG", "NGAYCAPNHAT", "ANHBIA" };
                foreach (var column in columnsToHide)
                {
                    if (dgvSPLienQuan.Columns.Contains(column))
                        dgvSPLienQuan.Columns[column].Visible = false;
                }
            }
        }

        private void QL_DatHang_Load(object sender, EventArgs e)
        {
            dgvSanPham.DataSource = datHangBLL.GetAllSanPham();
            LoadRecommendedProducts();
        }
    }
}
