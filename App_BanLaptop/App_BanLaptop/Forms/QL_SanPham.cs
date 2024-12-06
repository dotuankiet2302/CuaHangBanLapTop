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
using System.Drawing.Imaging;
using System.IO;

namespace App_BanLaptop.Forms
{
    public partial class QL_SanPham : Form
    {
        private bool isEditing = false;
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
            this.picAnhBia.Click += PicAnhBia_Click;
            SetInitialState();
        }

        private void PicAnhBia_Click(object sender, EventArgs e)
        {
            if (!isEditing) return;

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif)|*.jpg;*.jpeg;*.png;*.gif";
            openFileDialog.Title = "Chọn ảnh";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fileName = Path.GetFileName(openFileDialog.FileName);
                    string destinationPath = Path.Combine(Application.StartupPath, "Images", fileName);

                    // Giải phóng tài nguyên hình ảnh cũ
                    if (picAnhBia.Image != null)
                    {
                        picAnhBia.Image.Dispose();
                        picAnhBia.Image = null;
                    }

                    // Tạo bản sao của hình ảnh mới
                    using (var sourceImage = Image.FromFile(openFileDialog.FileName))
                    {
                        picAnhBia.Image = new Bitmap(sourceImage);
                        picAnhBia.SizeMode = PictureBoxSizeMode.StretchImage;
                    }

                    // Copy file vào thư mục Images
                    if (File.Exists(destinationPath))
                    {
                        System.Threading.Thread.Sleep(100);
                        File.Delete(destinationPath);
                    }
                    File.Copy(openFileDialog.FileName, destinationPath);

                    picAnhBia.Text = fileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi tải ảnh: " + ex.Message);
                }
            }
        }

        private void SetInitialState()
        {
            // Disable các controls nhập liệu
            picAnhBia.Enabled = false;
            txtMaMH.Enabled = false;
            txtTenMH.Enabled = false;
            txtMaTinhTrang.Enabled = false;
            txtGiaBan.Enabled = false;
            txtMoTa.Enabled = false;
            txtNgayCapNhat.Enabled = false;
            nUDSoLuong.Enabled = false;
            txtMaHang.Enabled = false;
            txtMaNSX.Enabled = false;

            // Đặt màu mờ cho nút Thêm và Sửa
            Them.Image = SetImageOpacity(Properties.Resources.them, 0.5f);
            Sua.Image = SetImageOpacity(Properties.Resources.sua, 0.5f);

            isEditing = false;
        }

        private void ClearControls()
        {
            txtMaMH.Clear();
            txtTenMH.Clear();
            txtMaTinhTrang.Clear();
            txtGiaBan.Clear();
            txtMoTa.Clear();
            txtNgayCapNhat.Clear();
            nUDSoLuong.Value = 0;
            txtMaHang.Clear();
            txtMaNSX.Clear();
            picAnhBia.Image = null;
        }


        private Image SetImageOpacity(Image image, float opacity)
        {
            try
            {
                Bitmap bmp = new Bitmap(image.Width, image.Height);
                using (Graphics gfx = Graphics.FromImage(bmp))
                {
                    ColorMatrix matrix = new ColorMatrix();
                    matrix.Matrix33 = opacity;
                    ImageAttributes attributes = new ImageAttributes();
                    attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
                    gfx.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
                }
                return bmp;
            }
            catch
            {
                return image;
            }
        }
        private void EnableEditingState()
        {
            // Enable các controls nhập liệu
            picAnhBia.Enabled = true;
            txtMaMH.Enabled = true;
            txtTenMH.Enabled = true;
            txtMaTinhTrang.Enabled = true;
            txtGiaBan.Enabled = true;
            txtMoTa.Enabled = true;
            txtNgayCapNhat.Enabled = true;
            nUDSoLuong.Enabled = true;
            txtMaHang.Enabled = true;
            txtMaNSX.Enabled = true;
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
            if (!isEditing)
            {
                isEditing = true;
                EnableEditingState();
                Sua.Image = Properties.Resources.sua;
            }
            else
            {
                try
                {
                    // Kiểm tra dữ liệu đầu vào tương tự như trong Them_Click
                    if (string.IsNullOrEmpty(txtMaMH.Text) || string.IsNullOrEmpty(txtTenMH.Text) ||
                        string.IsNullOrEmpty(txtMaTinhTrang.Text) || string.IsNullOrEmpty(txtGiaBan.Text) ||
                        string.IsNullOrEmpty(txtNgayCapNhat.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    laptop dt = new laptop();
                    if (!int.TryParse(txtMaMH.Text, out int maLap))
                    {
                        MessageBox.Show("Mã laptop phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    dt.MALAP = maLap;
                    dt.TENLAP = txtTenMH.Text;

                    if (!int.TryParse(txtMaTinhTrang.Text, out int maTT))
                    {
                        MessageBox.Show("Mã tình trạng phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    dt.MATINHTRANG = maTT;

                    if (!decimal.TryParse(txtGiaBan.Text, out decimal giaBan))
                    {
                        MessageBox.Show("Giá bán không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    dt.GIABAN = giaBan;

                    dt.MOTA = txtMoTa.Text;

                    if (!DateTime.TryParse(txtNgayCapNhat.Text, out DateTime ngayCN))
                    {
                        MessageBox.Show("Ngày cập nhật không hợp lệ! (định dạng: dd/MM/yyyy)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    dt.NGAYCAPNHAT = ngayCN;

                    DataGridViewRow currentRow = dgvSanPham.CurrentRow;
                    if (currentRow != null && !string.IsNullOrEmpty(picAnhBia.Text))
                    {
                        dt.ANHBIA = picAnhBia.Text;
                    }
                    else
                    {
                        dt.ANHBIA = currentRow.Cells["ANHBIA"].Value.ToString();
                    }


                    if (!int.TryParse(nUDSoLuong.Text, out int soLuong))
                    {
                        MessageBox.Show("Số lượng phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    dt.SOLUONGTON = soLuong;

                    if (!int.TryParse(txtMaHang.Text, out int maHang))
                    {
                        MessageBox.Show("Mã hãng phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    dt.MAHANG = maHang;

                    if (!int.TryParse(txtMaNSX.Text, out int maNSX))
                    {
                        MessageBox.Show("Mã NSX phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    dt.MANSX = maNSX;

                    if (bllLaptop.SuaLaptop(dt))
                    {
                        MessageBox.Show("Sửa Thành Công");
                        loadLaptop();
                        SetInitialState();
                    }
                    else
                    {
                        MessageBox.Show("Sửa Thất Bại");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
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
            if (!isEditing)
            {
                // Bắt đầu thêm mới
                isEditing = true;
                EnableEditingState();
                Them.Image = Properties.Resources.them;
                ClearControls();
            }
            else
            {
                try
                {
                    // Kiểm tra dữ liệu đầu vào
                    if (string.IsNullOrEmpty(txtMaMH.Text) || string.IsNullOrEmpty(txtTenMH.Text) ||
                        string.IsNullOrEmpty(txtMaTinhTrang.Text) || string.IsNullOrEmpty(txtGiaBan.Text) ||
                        string.IsNullOrEmpty(txtNgayCapNhat.Text))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    laptop dt = new laptop();
                    if (!int.TryParse(txtMaMH.Text, out int maLap))
                    {
                        MessageBox.Show("Mã laptop phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    dt.MALAP = maLap;
                    dt.TENLAP = txtTenMH.Text;

                    if (!int.TryParse(txtMaTinhTrang.Text, out int maTT))
                    {
                        MessageBox.Show("Mã tình trạng phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    dt.MATINHTRANG = maTT;

                    if (!decimal.TryParse(txtGiaBan.Text, out decimal giaBan))
                    {
                        MessageBox.Show("Giá bán không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    dt.GIABAN = giaBan;

                    dt.MOTA = txtMoTa.Text;

                    if (!DateTime.TryParse(txtNgayCapNhat.Text, out DateTime ngayCN))
                    {
                        MessageBox.Show("Ngày cập nhật không hợp lệ! (định dạng: dd/MM/yyyy)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    dt.NGAYCAPNHAT = ngayCN;

                    if (string.IsNullOrEmpty(picAnhBia.Text))
                    {
                        dt.ANHBIA = "errorImage.jpg";
                    }
                    else
                    {
                        dt.ANHBIA = picAnhBia.Text;
                    }

                    if (!int.TryParse(nUDSoLuong.Text, out int soLuong))
                    {
                        MessageBox.Show("Số lượng phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    dt.SOLUONGTON = soLuong;

                    if (!int.TryParse(txtMaHang.Text, out int maHang))
                    {
                        MessageBox.Show("Mã hãng phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    dt.MAHANG = maHang;

                    if (!int.TryParse(txtMaNSX.Text, out int maNSX))
                    {
                        MessageBox.Show("Mã NSX phải là số!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    dt.MANSX = maNSX;

                    if (bllLaptop.ThemLaptop(dt))
                    {
                        MessageBox.Show("Thêm Thành Công");
                        loadLaptop();
                        SetInitialState();
                    }
                    else
                    {
                        MessageBox.Show("Thêm Thất Bại");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
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
                    if (picAnhBia.Image != null)
                    {
                        picAnhBia.Image.Dispose();
                        picAnhBia.Image = null;
                    }

                    if (!string.IsNullOrEmpty(images))
                    {
                        string imagePath = Path.Combine(Application.StartupPath, "Images", images);
                        if (File.Exists(imagePath))
                        {
                            using (var sourceImage = Image.FromFile(imagePath))
                            {
                                picAnhBia.Image = new Bitmap(sourceImage);
                            }
                            picAnhBia.Text = images;
                        }
                        else
                        {
                            picAnhBia.Image = Properties.Resources.errorImage;
                            picAnhBia.Text = "errorImage.jpg";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải ảnh: " + ex.Message);
                    picAnhBia.Image = Properties.Resources.errorImage;
                    picAnhBia.Text = "errorImage.jpg";
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
