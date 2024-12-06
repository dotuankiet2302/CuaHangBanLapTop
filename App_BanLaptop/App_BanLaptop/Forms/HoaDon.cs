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
using Excel = Microsoft.Office.Interop.Excel;


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
            this.Xuat.Click += Xuat_Click;
        }

        private void Xuat_Click(object sender, EventArgs e)
        {
            try
            {
                // Tạo Excel Application
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Add();
                Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1];

                // Thiết lập header
                xlWorksheet.Cells[1, 1] = "LAPTOP STORE";
                Excel.Range headerRange = xlWorksheet.Range["A1:M1"];
                headerRange.Merge();
                headerRange.Font.Bold = true;
                headerRange.Font.Size = 18;
                headerRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;


                // Header của bảng dữ liệu
                string[] headers = new string[] {
                        "STT",
                        "Mã Hóa Đơn",
                        "Ngày Giao",
                        "Ngày Đặt",
                        "Trạng Thái Thanh Toán",
                        "Tình Trạng Giao",
                        "Mã Khách Hàng",
                        "Tên Khách Hàng",
                        "Mã Laptop",
                        "Tên Laptop",
                        "Số Lượng",
                        "Đơn Giá",
                        "Thành Tiền"
                    };
                for (int i = 0; i < headers.Length; i++)
                {
                    xlWorksheet.Cells[3, i + 1] = headers[i];
                    xlWorksheet.Cells[3, i + 1].Font.Bold = true;
                    xlWorksheet.Cells[3, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                }

                // Export dữ liệu từ DataGridView
                for (int i = 0; i < dgvHD.Rows.Count; i++)
                {
                    xlWorksheet.Cells[i + 4, 1] = i + 1; // Số thứ tự
                    for (int j = 0; j < dgvHD.Columns.Count; j++)
                    {
                        if (dgvHD.Rows[i].Cells[j].Value != null)
                        {
                            xlWorksheet.Cells[i + 4, j + 2] = dgvHD.Rows[i].Cells[j].Value.ToString();
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
                saveDialog.FileName = "HoaDon_" + txtMaDH.Text + "_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");

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

            // Đặt tên hiển thị cho các cột
            dgvHD.Columns["MADH"].HeaderText = "Mã ĐH";
            dgvHD.Columns["NGAYGIAO"].HeaderText = "Ngày Giao";
            dgvHD.Columns["NGAYDAT"].HeaderText = "Ngày Đặt";
            dgvHD.Columns["DATHANHTOAN"].HeaderText = "Thanh Toán";
            dgvHD.Columns["TINHTRANGGIAO"].HeaderText = "TT Giao";
            dgvHD.Columns["MAKH"].HeaderText = "Mã KH";
            dgvHD.Columns["TENKH"].HeaderText = "Tên KH";
            dgvHD.Columns["MALAP"].HeaderText = "Mã Laptop";
            dgvHD.Columns["TENLAP"].HeaderText = "Tên Laptop";
        }
        private void HoaDon_Load(object sender, EventArgs e)
        {
            LoadDonHang();
        }
    }
}
