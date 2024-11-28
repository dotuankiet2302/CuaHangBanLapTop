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
using Excel = Microsoft.Office.Interop.Excel;

namespace App_BanLaptop.Forms
{
    public partial class QL_SanPham : Form
    {
        LaptopBLL bllLaptop = new LaptopBLL();
        public QL_SanPham()
        {
            InitializeComponent();
            this.Load += QL_SanPham_Load;
            this.WindowState = FormWindowState.Maximized;
            this.dgvSanPham.CellClick += DgvSanPham_CellClick;
            this.Them.Click += Them_Click;
            this.Xoa.Click += Xoa_Click;
            this.Sua.Click += Sua_Click;
            btnTimKiem.Click += BtnTimKiem_Click;
            txtTimKiem.TextChanged += TxtTimKiem_TextChanged;
            this.In.Click += In_Click;
            this.Resize += QL_SanPham_Resize;
            this.Xuat.Click += Xuat_Click;
        }

        private void Xuat_Click(object sender, EventArgs e)
        {
            try
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Add();
                Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1];

                // Tạo tiêu đề
                xlWorksheet.Cells[1, 1] = "DANH SÁCH SẢN PHẨM LAPTOP";
                Excel.Range titleRange = xlWorksheet.Range[xlWorksheet.Cells[1, 1], xlWorksheet.Cells[1, dgvSanPham.Columns.Count]];
                titleRange.Merge();
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 16;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // Export header của DataGridView
                for (int i = 0; i < dgvSanPham.Columns.Count; i++)
                {
                    xlWorksheet.Cells[3, i + 1] = dgvSanPham.Columns[i].HeaderText;
                    xlWorksheet.Cells[3, i + 1].Font.Bold = true;
                    xlWorksheet.Cells[3, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                }

                // Export nội dung của DataGridView
                for (int i = 0; i < dgvSanPham.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvSanPham.Columns.Count; j++)
                    {
                        if (dgvSanPham.Rows[i].Cells[j].Value != null)
                        {
                            // Định dạng đặc biệt cho cột giá bán
                            if (dgvSanPham.Columns[j].Name == "GIABAN" || dgvSanPham.Columns[j].HeaderText.Contains("Giá"))
                            {
                                xlWorksheet.Cells[i + 4, j + 1] = dgvSanPham.Rows[i].Cells[j].Value;
                                xlWorksheet.Cells[i + 4, j + 1].NumberFormat = "#,##0";
                            }
                            // Định dạng đặc biệt cho cột ngày
                            else if (dgvSanPham.Columns[j].Name == "NGAYCAPNHAT")
                            {
                                xlWorksheet.Cells[i + 4, j + 1] = dgvSanPham.Rows[i].Cells[j].Value;
                                xlWorksheet.Cells[i + 4, j + 1].NumberFormat = "dd/mm/yyyy";
                            }
                            else
                            {
                                xlWorksheet.Cells[i + 4, j + 1] = dgvSanPham.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }
                }

                // Tự động điều chỉnh độ rộng cột
                xlWorksheet.Columns.AutoFit();

                // Thêm đường viền
                Excel.Range range = xlWorksheet.UsedRange;
                range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

                // Hiển thị SaveFileDialog
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 1;
                saveDialog.FileName = "DanhSachLaptop_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    xlWorkbook.SaveAs(saveDialog.FileName);
                    xlWorkbook.Close();
                    xlApp.Quit();

                    MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // Giải phóng tài nguyên
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlWorkbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void QL_SanPham_Resize(object sender, EventArgs e)
        {
            AdjustLayout();
        }

        private void In_Click(object sender, EventArgs e)
        {
            if (dgvSanPham.Rows.Count > 0)
            {
                string tenLap = txtTenMH.Text;
                string moTa = txtMoTa.Text;
                string ngayCN = txtNgayCapNhat.Text;
                if (tenLap == "" || moTa == "" || ngayCN == "")
                {
                    MessageBox.Show("Hãy chọn 1 hàng trước.");
                    return;
                }

                WordExport dt = new WordExport();
                dt.XacNhanChatLuongSP(tenLap, moTa, ngayCN);
            }
            else
            {
                MessageBox.Show("Hãy chọn 1 hàng trước.");
            }
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
            AdjustLayout();
            dgvSanPham.DataSource = bllLaptop.GetLaptop();
        }
        private void QL_SanPham_Load(object sender, EventArgs e)
        {
            loadLaptop();
        }
        private void AdjustLayout()
        {
            dgvSanPham.Dock = DockStyle.None;
            int margin = 20;
            dgvSanPham.Location = new Point(margin, 300);
            dgvSanPham.Width = this.ClientSize.Width - (margin * 2);
            dgvSanPham.Height = 250;
        }
    }
}
