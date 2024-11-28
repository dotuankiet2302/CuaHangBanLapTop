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
using Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;


namespace App_BanLaptop.Forms
{
    public partial class QL_KhachHang : Form
    {
        KhachHangBLL bllKhachHang = new KhachHangBLL();
        public QL_KhachHang()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.txtMakh.Enabled = false;
            
            // Thiết lập Anchor cho DataGridView
            dgvKH.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            
            // Các event handlers khác
            this.Load += QL_KhachHang_Load;
            this.dgvKH.CellClick += DgvKH_CellClick;
            this.Them.Click += Them_Click;
            this.Sua.Click += Sua_Click;
            this.Xoa.Click += Xoa_Click;
            cbHienThiMK.CheckedChanged += CbHienThiMK_CheckedChanged;
            this.dgvKH.CellFormatting += DgvKH_CellFormatting;
            this.btnSearch.Click += BtnSearch_Click;
            txtTimKiem.TextChanged += TxtTimKiem_TextChanged;
            this.In.Click += In_Click;
            this.Xuat.Click += Xuat_Click;
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            this.AutoScaleMode = AutoScaleMode.None;
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            // Điều chỉnh lại kích thước các control khi form thay đổi kích thước
            dgvKH.Height = this.Height - 250; // Điều chỉnh chiều cao của DataGridView
            // Điều chỉnh các control khác nếu cần
        }

        private void Xuat_Click(object sender, EventArgs e)
        {
            try
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Add();
                Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1];

                // Tạo tiêu đề
                xlWorksheet.Cells[1, 1] = "DANH SÁCH KHÁCH HÀNG";
                Excel.Range titleRange = xlWorksheet.Range[xlWorksheet.Cells[1, 1], xlWorksheet.Cells[1, dgvKH.Columns.Count]];
                titleRange.Merge();
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 16;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // Export header của DataGridView
                for (int i = 0; i < dgvKH.Columns.Count; i++)
                {
                    xlWorksheet.Cells[3, i + 1] = dgvKH.Columns[i].HeaderText;
                    xlWorksheet.Cells[3, i + 1].Font.Bold = true;
                    xlWorksheet.Cells[3, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                }

                // Export nội dung của DataGridView
                for (int i = 0; i < dgvKH.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvKH.Columns.Count; j++)
                    {
                        if (dgvKH.Rows[i].Cells[j].Value != null)
                        {
                            // Xử lý đặc biệt cho cột mật khẩu
                            if (dgvKH.Columns[j].DataPropertyName == "MATKHAU")
                            {
                                xlWorksheet.Cells[i + 4, j + 1] = "********";
                            }
                            else
                            {
                                xlWorksheet.Cells[i + 4, j + 1] = dgvKH.Rows[i].Cells[j].Value.ToString();
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
                saveDialog.FileName = "DanhSachKhachHang_" + DateTime.Now.ToString("ddMMyyyy_HHmmss");

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
            if (dgvKH.Rows.Count > 0)
            {
                string hoTen = txtTenkh.Text;
                string ngaySinh = txtNgaySinh.Text;
                if(hoTen == "" || ngaySinh == "")
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
            QLKhachHangTableAdapter qlKH = new QLKhachHangTableAdapter();
            if (txtTimKiem.Text == "")
            {
                loadKhachHang();
            }
            else if (cboTimKiem.Text == "Mã Khách Hàng")
            {
                int maKhachHang;
                if (int.TryParse(txtTimKiem.Text, out maKhachHang))
                {
                    // Nếu chuyển đổi thành công, thực hiện tìm kiếm
                    dgvKH.DataSource = qlKH.GetDataBy3(maKhachHang);
                }
                else
                {
                    // Nếu chuyển đổi thất bại, thông báo lỗi cho người dùng
                    MessageBox.Show("Vui lòng nhập mã khách hàng là số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                int maKhachHang;
                if (int.TryParse(txtTimKiem.Text, out maKhachHang))
                {
                    // Nếu chuyển đổi thành công, thực hiện tìm kiếm
                    dgvKH.DataSource = qlKH.GetDataBy3(maKhachHang);
                }
                else
                {
                    // Nếu chuyển đổi thất bại, thông báo lỗi cho người dùng
                    MessageBox.Show("Vui lòng nhập mã khách hàng là số.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if(cboTimKiem.Text == "Tên Khách Hàng")
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
            //System.Data.DataTable dataTable = qlKH.GetData(); 
            dgvKH.DataSource = qlKH.GetData();
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
