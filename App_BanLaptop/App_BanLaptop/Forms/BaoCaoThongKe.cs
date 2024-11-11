using App_BanLaptop.doan_laptopTableAdapters;
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

namespace App_BanLaptop.Forms
{
    public partial class BaoCaoThongKe : Form
    {
        public BaoCaoThongKe()
        {
            InitializeComponent();
            this.Load += BaoCaoThongKe_Load;
            this.btnThongKe.Click += BtnThongKe_Click;
        }

        private void BtnThongKe_Click(object sender, EventArgs e)
        {
            if (rdoMacDinh.Checked)
            {
                ThongKeTableAdapter ql_ThongKe = new ThongKeTableAdapter();
                ql_ThongKe.GetData();
                TongThongKeTableAdapter ql_TongThongKe = new TongThongKeTableAdapter();
                ql_TongThongKe.GetData();
            }
            else
            {
                DateTime value = dtpNgayBD.Value;
                DateTime value1 = dtpNgayKT.Value;
                DateTime newDateTimeFrom = new DateTime(value.Year, value.Month, value.Day, value.Hour, value.Minute, value.Second);
                DateTime newDateTimeTo = new DateTime(value1.Year, value1.Month, value1.Day, value1.Hour, value1.Minute, value1.Second);
                //TongThongKeTableAdapter ql_TongThongKe = new TongThongKeTableAdapter();
                //ql_TongThongKe.GetDataBy(newDateTimeFrom, newDateTimeTo);
                string strNewDateTimeFrom = newDateTimeFrom.ToString("yyyy-MM-dd");  // Adjust format if needed
                string strNewDateTimeTo = newDateTimeTo.ToString("yyyy-MM-dd HH:mm:ss");  // Adjust format if needed

                TongThongKeTableAdapter ql_TongThongKe = new TongThongKeTableAdapter();
                ql_TongThongKe.GetDataBy(strNewDateTimeFrom, strNewDateTimeTo);
            }
        }

        private void BaoCaoThongKe_Load(object sender, EventArgs e)
        {
            ThongKeTableAdapter ql_ThongKe = new ThongKeTableAdapter();
            ql_ThongKe.GetData();
            TongThongKeTableAdapter ql_TongThongKe = new TongThongKeTableAdapter();
            ql_TongThongKe.GetData();
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
