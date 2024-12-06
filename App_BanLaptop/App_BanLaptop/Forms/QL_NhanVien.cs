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
using App_BanLaptop.doan_laptopTableAdapters;
using Excel = Microsoft.Office.Interop.Excel;

namespace App_BanLaptop.Forms
{
    public partial class QL_NhanVien : Form
    {
        NhanVienBLL bllNhanVien = new NhanVienBLL();
        public QL_NhanVien()
        {
            InitializeComponent();
            this.AutoSize = false;   
            this.txtManv.Enabled = false;
            this.dgvNhanVien.CellClick += DgvNhanVien_CellClick;
            this.Them.Click += Them_Click;
            this.Sua.Click += Sua_Click;
            this.Xoa.Click += Xoa_Click;
            this.cbHienThiMK.CheckedChanged += CbHienThiMK_CheckedChanged;
            this.dgvNhanVien.CellFormatting += DgvNhanVien_CellFormatting;
            this.btnTimKiem.Click += BtnTimKiem_Click;
            this.txtTimKiem.TextChanged += TxtTimKiem_TextChanged;
            this.In.Click += In_Click;
            #if DEBUG
                this.AutoScaleMode = AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(800, 500);
            #endif
            this.Load += new EventHandler(QL_NhanVien_Load);
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
                xlWorksheet.Cells[1, 1] = "DANH SÁCH NHÂN VIÊN";
                Excel.Range titleRange = xlWorksheet.Range[xlWorksheet.Cells[1, 1], xlWorksheet.Cells[1, dgvNhanVien.Columns.Count]];
                titleRange.Merge();
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 16;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // Export header của DataGridView
                for (int i = 0; i < dgvNhanVien.Columns.Count; i++)
                {
                    xlWorksheet.Cells[3, i + 1] = dgvNhanVien.Columns[i].HeaderText;
                    xlWorksheet.Cells[3, i + 1].Font.Bold = true;
                    xlWorksheet.Cells[3, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                }

                // Export nội dung của DataGridView
                for (int i = 0; i < dgvNhanVien.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvNhanVien.Columns.Count; j++)
                    {
                        if (dgvNhanVien.Rows[i].Cells[j].Value != null)
                        {
                            // Xử lý đặc biệt cho cột mật khẩu
                            if (dgvNhanVien.Columns[j].DataPropertyName == "MATKHAU")
                            {
                                xlWorksheet.Cells[i + 4, j + 1] = "********";
                            }
                            else
                            {
                                xlWorksheet.Cells[i + 4, j + 1] = dgvNhanVien.Rows[i].Cells[j].Value.ToString();
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
                saveDialog.FileName = "DanhSachNhanVien_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");

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

        private void In_Click(object sender, EventArgs e)
        {
            if (dgvNhanVien.Rows.Count > 0)
            {
                string hoTen = txtTennv.Text;
                string ngaySinh = txtNgaySinh.Text;
                if (hoTen == "" || ngaySinh == "")
                {
                    MessageBox.Show("Hãy chọn 1 hàng trước.");
                    return;
                }

                WordExport dt = new WordExport();
                dt.QuyetDinhKhenThuong(hoTen, ngaySinh);
            }
            else
            {
                MessageBox.Show("Hãy chọn 1 hàng trước.");
            }
        }

        private void TxtTimKiem_TextChanged(object sender, EventArgs e) 
        {
            QLNhanVienTableAdapter qlNV = new QLNhanVienTableAdapter();
            if (txtTimKiem.Text == "")
            {
                loadNhanVien();
            }
            else if (cboTimKiem.Text == "Mã Nhân Viên")
            {
                int maNV;
                if (int.TryParse(txtTimKiem.Text, out maNV))
                {
                    // Nếu chuyển đổi thành công, thực hiện tìm kiếm
                    dgvNhanVien.DataSource = qlNV.GetDataBy3(maNV);
                }
                else
                {
                    // Nếu chuyển đổi thất bại, thông báo lỗi cho người dùng
                    MessageBox.Show("Vui lòng nhập mã nhân viên là số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (cboTimKiem.Text == "Tên Nhân Viên")
            {
                dgvNhanVien.DataSource = qlNV.GetDataBy4(txtTimKiem.Text);
            }
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            QLNhanVienTableAdapter qlNV = new QLNhanVienTableAdapter();
            if (txtTimKiem.Text == "")
            {
                loadNhanVien();
            }
            else if (cboTimKiem.Text == "Mã Nhân Viên")
            {
                int maNV;
                if (int.TryParse(txtTimKiem.Text, out maNV))
                {
                    // Nếu chuyển đổi thành công, thực hiện tìm kiếm
                    dgvNhanVien.DataSource = qlNV.GetDataBy3(maNV);
                }
                else
                {
                    // Nếu chuyển đổi thất bại, thông báo lỗi cho người dùng
                    MessageBox.Show("Vui lòng nhập mã nhân viên là số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (cboTimKiem.Text == "Tên Nhân Viên")
            {
                dgvNhanVien.DataSource = qlNV.GetDataBy4(txtTimKiem.Text);
            }
        }

        private void DgvNhanVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvNhanVien.Columns[e.ColumnIndex].DataPropertyName == "MATKHAU" && e.Value != null)
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
            //int maNhanVien = int.Parse(txtManv.Text); // Lấy mã môn học từ textbox

            //if (bllNhanVien.XoaNhanVien(maNhanVien))
            //{
            //    MessageBox.Show("Xóa Thành Công");
            //    loadNhanVien(); // Gọi hàm load lại danh sách môn học
            //}
            //else
            //{
            //    MessageBox.Show("Xóa Thất bại");
            //    //// Kiểm tra xem mã không tồn tại hay có điểm liên quan
            //    //var hasScores = bllNhanVien.KiemTraDiemMon(maNhanVien);
            //    //if (hasScores)
            //    //{
            //    //    MessageBox.Show("Không thể xóa. Môn học này đã có điểm liên quan.");
            //    //}
            //    //else
            //    //{
            //    //    MessageBox.Show("Mã môn học '" + maNhanVien + "' không tồn tại. Không thể xóa.");
            //    //}
            //}
            int MaNV = Convert.ToInt32(txtManv.Text);
            QLNhanVienTableAdapter qlNV = new QLNhanVienTableAdapter();

            var existingRecord = qlNV.GetData().FirstOrDefault(kh => kh.MAKH == MaNV);
            if (existingRecord != null)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    qlNV.Xoa(MaNV);
                    MessageBox.Show("Xóa nhân viên thành công");

                    loadNhanVien();
                }
            }
            else
            {
                MessageBox.Show("Mã Nhân Viên không tồn tại. Vui lòng kiểm tra lại.");
            }
        }

        private void Sua_Click(object sender, EventArgs e)
        {
            //string sex = radioButtonNam.Checked ? "NAM" : "NỮ";
            //khachhang dt = new khachhang();
            //dt.MAKH = int.Parse(txtManv.Text);
            //dt.HOTEN = txtTennv.Text;
            //dt.NGAYSINH = DateTime.Parse(txtNgaySinh.Text);
            //dt.GIOITINH = sex;
            //dt.DIENTHOAI = txtPhone.Text;
            //dt.TAIKHOAN = txtUserName.Text;
            //dt.MATKHAU = txtPass.Text;
            //dt.EMAIL = txtEmail.Text;
            //dt.DIACHI = txtAddress.Text;
            //dt.MAQUYEN = int.Parse(txtMaQuyen.Text);
            //dt.MATINH = int.Parse(txtMaTinh.Text);

            //if (bllNhanVien.SuaNhanVien(dt))
            //{
            //    MessageBox.Show("Sửa Thành Công");
            //    loadNhanVien(); 
            //}
            //else
            //{
            //    MessageBox.Show("Sửa Thất Bại");
            //}
            string gender = radioButtonNam.Checked ? "NAM" : "NỮ";
            QLNhanVienTableAdapter qlNV = new QLNhanVienTableAdapter();
            int MaNV = Convert.ToInt32(txtManv.Text);
            string HoTen = txtTennv.Text;
            string NgaySinh = txtNgaySinh.Text;
            string GioiTinh = gender;
            string DienThoai = txtPhone.Text;
            string TaiKhoan = txtUserName.Text;
            string MatKhau = txtPass.Text;
            string Email = txtEmail.Text;
            string DiaChi = txtAddress.Text;
            int MaTinh = Convert.ToInt32(txtMaTinh.Text);

            var existingRecord = qlNV.GetData().FirstOrDefault(kh => kh.MAKH == MaNV);
            if (existingRecord != null)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn sửa thông tin nhân viên này không?", "Xác nhận sửa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    qlNV.Sua(HoTen, NgaySinh, GioiTinh, DienThoai, TaiKhoan, MatKhau, Email, DiaChi, MaTinh, MaNV);
                    MessageBox.Show("Sửa nhân viên thành công");
                    loadNhanVien();
                }
            }
            else
            {
                MessageBox.Show("Mã Nhân Viên không tồn tại. Vui lòng kiểm tra lại.");
            }
        }

        private void Them_Click(object sender, EventArgs e)
        {
            //string sex = radioButtonNam.Checked ? "NAM" : "NỮ";
            //khachhang dt = new khachhang();
            //dt.MAKH = int.Parse(txtManv.Text);
            //dt.HOTEN = txtTennv.Text;
            //dt.NGAYSINH = DateTime.Parse(txtNgaySinh.Text);
            //dt.GIOITINH = sex;
            //dt.DIENTHOAI = txtPhone.Text;
            //dt.TAIKHOAN = txtUserName.Text;
            //dt.MATKHAU = txtPass.Text; 
            //dt.EMAIL = txtEmail.Text;
            //dt.DIACHI = txtAddress.Text;
            //dt.MAQUYEN = int.Parse(txtMaQuyen.Text);
            //dt.MATINH = int.Parse(txtMaTinh.Text);

            //if (bllNhanVien.ThemNhanVien(dt))
            //{
            //    MessageBox.Show("Thanh Cong");
            //    loadNhanVien();
            //}
            //else
            //{
            //    MessageBox.Show("That Bai");
            //}
            string gender = radioButtonNam.Checked ? "NAM" : "NỮ";
            QLNhanVienTableAdapter qlKH = new QLNhanVienTableAdapter();
            string HoTen = txtTennv.Text;
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
                loadNhanVien();
                MessageBox.Show("Thành Công");
            }
            else
            {
                MessageBox.Show("Tên Tài Khoản đã tồn tại. Vui lòng chọn giá trị khác.");
            }
        }

        private void DgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

                txtManv.Text = row.Cells[0].Value.ToString();
                txtTennv.Text = row.Cells[1].Value.ToString();
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

        public void loadNhanVien()
        {
            this.WindowState = FormWindowState.Normal;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            QLNhanVienTableAdapter qlNV = new QLNhanVienTableAdapter();
            DataTable dataTable = qlNV.GetData();
            dgvNhanVien.DataSource = dataTable;
        }
        private void QL_NhanVien_Load(object sender, EventArgs e)
        {
            loadNhanVien();
        }
        private void qLNhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.qLNhanVienBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.doan_laptop);

        }

        private void QL_NhanVien_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'doan_laptop.QLNhanVien' table. You can move, or remove it, as needed.
            this.qLNhanVienTableAdapter.Fill(this.doan_laptop.QLNhanVien);

        }
    }
}
