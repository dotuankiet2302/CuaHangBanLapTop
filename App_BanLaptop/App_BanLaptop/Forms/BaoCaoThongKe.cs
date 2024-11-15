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
            this.Load += BaoCaoThongKe_Load;
            this.btnThongKe.Click += BtnThongKe_Click;
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
