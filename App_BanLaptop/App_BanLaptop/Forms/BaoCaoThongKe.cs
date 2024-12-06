using App_BanLaptop.doan_laptopTableAdapters;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Common;

namespace App_BanLaptop.Forms
{
    public partial class BaoCaoThongKe : Form
    {
        DataSet ds;
        SqlDataAdapter da;
        string conn = "Data Source=LAPTOP-E8D06NHE\\SQLEXPRESS;Initial Catalog=doan_laptop;User ID=sa;Password=123";
        public BaoCaoThongKe()
        {
            InitializeComponent();
            this.Dock = DockStyle.Fill;
            this.Load += BaoCaoThongKe_Load;
            this.btnThongKe.Click += BtnThongKe_Click;
            this.Xuat.Click += Xuat_Click;
        }

        private void Xuat_Click(object sender, EventArgs e)
        {
            try
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Add();
                Excel.Worksheet xlWorksheet = xlWorkbook.Sheets[1];

                // Thêm tiêu đề
                string title;
                if (rdoMacDinh.Checked)
                {
                    title = "DANH SÁCH THỐNG KÊ CÁC ĐƠN HÀNG";
                }
                else
                {
                    title = $"DANH SÁCH THỐNG KÊ TỪ NGÀY {dtpNgayBD.Value.ToString("dd/MM/yyyy")} ĐẾN NGÀY {dtpNgayKT.Value.ToString("dd/MM/yyyy")}";
                }
                xlWorksheet.Cells[1, 1] = title;
                Excel.Range titleRange = xlWorksheet.Range[xlWorksheet.Cells[1, 1], xlWorksheet.Cells[1, dgvThongKe.Columns.Count]];
                titleRange.Merge();
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 14;

                // Thêm thông tin người xuất báo cáo
                string nguoiXuat = string.IsNullOrEmpty(SessionManager.CurrentUserName) ? 
                                "Admin" : SessionManager.CurrentUserName;
                xlWorksheet.Cells[2, 1] = $"Người xuất báo cáo: {nguoiXuat}";
                
                // Thêm ngày xuất báo cáo
                xlWorksheet.Cells[3, 1] = $"Ngày xuất báo cáo: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}";
                
                // Export header của DataGridView
                for (int i = 0; i < dgvThongKe.Columns.Count; i++)
                {
                    xlWorksheet.Cells[5, i + 1] = dgvThongKe.Columns[i].HeaderText;
                    // Định dạng header
                    Excel.Range headerCell = xlWorksheet.Cells[5, i + 1];
                    headerCell.Font.Bold = true;
                    headerCell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                }

                // Export nội dung của DataGridView
                for (int i = 0; i < dgvThongKe.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvThongKe.Columns.Count; j++)
                    {
                        if (dgvThongKe.Rows[i].Cells[j].Value != null)
                        {
                            xlWorksheet.Cells[i + 6, j + 1] = dgvThongKe.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                }

                // Tự động điều chỉnh độ rộng cột
                xlWorksheet.Columns.AutoFit();

                // Hiển thị SaveFileDialog
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 1;
                saveDialog.FileName = "ThongKeBanHang_" + DateTime.Now.ToString("ddMMyyyy");

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    xlWorkbook.SaveAs(saveDialog.FileName);
                    xlWorkbook.Close();
                    xlApp.Quit();

                    MessageBox.Show("Xuất file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi xuất file: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void Load_DgvBaoCao_ThongKe()
        {
            ds = new DataSet();
            string sql = "SELECT l.TENLAP, l.GIABAN, ctdh.SOLUONG, dh.NGAYDAT, SUM(ctdh.SOLUONG * l.GIABAN) AS TONGTIEN FROM [doan_laptop].[dbo].[donhang] dh JOIN [doan_laptop].[dbo].[chitietdonhang] ctdh ON dh.MADH = ctdh.MADH JOIN [doan_laptop].[dbo].[laptop] l ON ctdh.MALAP = l.MALAP GROUP BY l.TENLAP, l.GIABAN, ctdh.SOLUONG, dh.NGAYDAT";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "MATHANG_CT_HD_HOADON");
            dgvThongKe.DataSource = ds.Tables["MATHANG_CT_HD_HOADON"];

        }
        void Load_DgvTongDoanhThu()
        {
            ds = new DataSet();
            string sql = "SELECT SUM(ctdh.SOLUONG) AS TONGSOLUONG, SUM(ctdh.SOLUONG * l.GIABAN) AS TONGDOANHTHU FROM [doan_laptop].[dbo].[chitietdonhang] ctdh JOIN   [doan_laptop].[dbo].[laptop] l ON ctdh.MALAP = l.MALAP;";
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "MATHANG_CT_HD_HOADON");
            dgvSoLuong_DoanhThu.DataSource = ds.Tables["MATHANG_CT_HD_HOADON"];

        }
        void Load_DgvTongSL_DTTheoNgay()
        {
            DateTime value = dtpNgayBD.Value;
            DateTime value1 = dtpNgayKT.Value;
            DateTime newDateTimeFrom = new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, value.Second);
            DateTime newDateTimeTo = new DateTime(value1.Year, value1.Month, value1.Day, value1.Hour, value1.Minute, value1.Second);
            //TongThongKeTableAdapter ql_TongThongKe = new TongThongKeTableAdapter();
            //ql_TongThongKe.GetDataBy(newDateTimeFrom, newDateTimeTo);
            //string NgayBD = newDateTimeFrom.ToString("MM-dd-yyyy");  // Adjust format if needed
            //string NgayKT = newDateTimeTo.ToString("MM-dd-yyyy");  // Adjust format if needed

            //dgvTongThongKe.Columns.Remove("NGAYLAP");
            string sql = "SELECT CONVERT(VARCHAR(10), hd.NGAYDAT, 101) AS NGAYLAP, SUM(ct.SOLUONG) AS TONGSOLUONG, SUM(ct.SOLUONG * m.GIABAN) AS TONGDOANHTHU FROM chitietdonhang ct JOIN laptop m ON ct.MALAP = m.MALAP JOIN donhang hd ON ct.MADH = hd.MADH WHERE hd.NGAYDAT BETWEEN '" + newDateTimeFrom + "' AND '" + newDateTimeTo + "' GROUP BY CONVERT(VARCHAR(10), hd.NGAYDAT, 101) ORDER BY NGAYLAP";
            
            ds = new DataSet();
            da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "TongThongKe");
            dgvSoLuong_DoanhThu.DataSource = ds.Tables["TongThongKe"];

        }

        void Load_DgvDoanhThuTheoNgay()
        {
            DateTime value = dtpNgayBD.Value;
            DateTime value1 = dtpNgayKT.Value;
            DateTime newDateTimeFrom = new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, value.Second);
            DateTime newDateTimeTo = new DateTime(value1.Year, value1.Month, value1.Day, value1.Hour, value1.Minute, value1.Second);
            //TongThongKeTableAdapter ql_TongThongKe = new TongThongKeTableAdapter();
            //ql_TongThongKe.GetDataBy(newDateTimeFrom, newDateTimeTo);
            //string NgayBD = newDateTimeFrom.ToString("MM-dd-yyyy");  // Adjust format if needed
            //string NgayKT = newDateTimeTo.ToString("MM-dd-yyyy");  // Adjust format if needed

            string sql = "SELECT m.TENLAP, m.GIABAN, ct.SOLUONG, hd.NGAYDAT, ct.SOLUONG* m.GIABAN AS TONGTIEN FROM chitietdonhang ct JOIN laptop m ON ct.MALAP = m.MALAP JOIN donhang hd ON ct.MADH = hd.MADH WHERE hd.NGAYDAT BETWEEN '" + newDateTimeFrom + "' AND '" + newDateTimeTo + "'";
            
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.Fill(ds, "ThongKe");
            dgvThongKe.DataSource = ds.Tables["ThongKe"];
        }

        private void BtnThongKe_Click(object sender, EventArgs e)
        {
            if (rdoTheoNgay.Checked)
            {
                Load_DgvDoanhThuTheoNgay();
                Load_DgvTongSL_DTTheoNgay();
            }
            else
            {
                loadBaoCaoThongKe();
            }
        }

        public void loadBaoCaoThongKe()
        {
            //ThongKeTableAdapter ql_ThongKe = new ThongKeTableAdapter();
            //ql_ThongKe.GetData();
            //TongThongKeTableAdapter ql_TongThongKe = new TongThongKeTableAdapter();
            //ql_TongThongKe.GetData();
            Load_DgvBaoCao_ThongKe();
        }

        private void BaoCaoThongKe_Load(object sender, EventArgs e)
        {
            loadBaoCaoThongKe();
            Load_DgvTongDoanhThu();
        }

        private void chitietdonhangBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.chitietdonhangBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.doan_laptop);

        }

        private void BaoCaoThongKe_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'doan_laptop.TongThongKe' table. You can move, or remove it, as needed.
            this.tongThongKeTableAdapter.Fill(this.doan_laptop.TongThongKe);
            // TODO: This line of code loads data into the 'doan_laptop.ThongKe' table. You can move, or remove it, as needed.
            this.thongKeTableAdapter.Fill(this.doan_laptop.ThongKe);

        }
    }
}
