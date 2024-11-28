using App_BanLaptop.doan_laptopTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace App_BanLaptop.Forms
{
    public partial class TinTuc : Form
    {
        public TinTuc()
        {
            InitializeComponent();
            this.Load += TinTuc_Load1;
            this.dgvQLTinTuc.CellClick += DgvQLTinTuc_CellClick;
            this.Them.Click += Them_Click;
            this.Sua.Click += Sua_Click;
            this.Xoa.Click += Xoa_Click;
        }
        private void Xoa_Click(object sender, EventArgs e)
        {
            int maTin = Convert.ToInt32(txtMaTin.Text);
            QLTinTucTableAdapter qlTT = new QLTinTucTableAdapter();

            var existingRecord = qlTT.GetData().FirstOrDefault(kh => kh.MATIN == maTin);
            if (existingRecord != null)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa tin tức này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    qlTT.Xoa(maTin);
                    MessageBox.Show("Xóa tin tức thành công");

                    loadTinTuc();
                }
            }
            else
            {
                MessageBox.Show("Mã Tin tức không tồn tại. Vui lòng kiểm tra lại.");
            }
        }

        private void Sua_Click(object sender, EventArgs e)
        {
            QLTinTucTableAdapter qlTT = new QLTinTucTableAdapter();
            int maTin = int.Parse(txtMaTin.Text);
            string tieuDe = txtTieuDe.Text;
            string noiDung = txtNoiDung.Text;
            string hinhAnh = picHInhAnh.Text;
            string ngayDang = txtNgayDang.Text;
            int maLoaiTin = 1;
            if (txtMaLoaiTin.Text == "TIN TỨC MỚI NHẤT")
            {
                maLoaiTin = 1;
            }
            else if (txtMaLoaiTin.Text == "TIN KHUYẾN MẠI")
            {
                maLoaiTin = 2;
            }
            else if (txtMaLoaiTin.Text == "TIN TỨC KHÁC")
            {
                maLoaiTin = 3;
            }

            qlTT.Sua(tieuDe, noiDung, hinhAnh, ngayDang, maLoaiTin, maTin);
            loadTinTuc();
            MessageBox.Show("Thành Công");
        }

        private void Them_Click(object sender, EventArgs e)
        {
            QLTinTucTableAdapter qlTT = new QLTinTucTableAdapter();
            int maTin = int.Parse(txtMaTin.Text);
            string tieuDe = txtTieuDe.Text;
            string noiDung = txtNoiDung.Text;
            string hinhAnh = picHInhAnh.Text;
            string ngayDang = txtNgayDang.Text;
            int maLoaiTin = 1;
            if (txtMaLoaiTin.Text == "TIN TỨC MỚI NHẤT")
            {
                maLoaiTin = 1;
            }
            else if (txtMaLoaiTin.Text == "TIN KHUYẾN MẠI")
            {
                maLoaiTin = 2;
            }
            else if (txtMaLoaiTin.Text == "TIN TỨC KHÁC")
            {
                maLoaiTin = 3;
            }

            // Kiểm tra xem MaTinh đã tồn tại hay chưa
            var existingRecord = qlTT.GetData().FirstOrDefault(kh => kh.MATIN == maTin);
            if (existingRecord == null)
            {
                qlTT.Them(maTin, tieuDe, noiDung, hinhAnh, ngayDang, maLoaiTin);
                loadTinTuc();
                MessageBox.Show("Thành Công");
            }
            else
            {
                MessageBox.Show("Tên Tài Khoản đã tồn tại. Vui lòng chọn giá trị khác.");
            }
        }

        private void DgvQLTinTuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvQLTinTuc.Rows[e.RowIndex];

                txtMaTin.Text = row.Cells[0].Value.ToString();
                txtTieuDe.Text = row.Cells[1].Value.ToString();
                txtNoiDung.Text = row.Cells[2].Value.ToString();
                string images = row.Cells[3].Value.ToString();
                txtNgayDang.Text = row.Cells[4].Value.ToString();
                if (row.Cells[5].Value.ToString() == "TIN TỨC MỚI NHẤT")
                    txtMaLoaiTin.Text = "1";
                else if (row.Cells[5].Value.ToString() == "TIN KHUYẾN MẠI")
                    txtMaLoaiTin.Text = "2";
                else if (row.Cells[5].Value.ToString() == "TIN TỨC KHÁC")
                    txtMaLoaiTin.Text = "3";
                //txtMaLoaiTin.Text = row.Cells[6].Value.ToString();
                try
                {
                    picHInhAnh.Image = new Bitmap(Application.StartupPath + "\\Images\\" + images);
                }
                catch (ArgumentException ex)
                {
                    // Handle the exception, e.g., display an error message or set a default image
                    MessageBox.Show("Chưa có ảnh cho tin tức này!!!\n" + ex.Message);
                    picHInhAnh.Image = new Bitmap(Application.StartupPath + "\\Images\\errorImage.jpg");
                }
            }
        }

        private void TinTuc_Load1(object sender, EventArgs e)
        {
            loadTinTuc();
        }

        public void loadTinTuc()
        {
            QLTinTucTableAdapter qlTT = new QLTinTucTableAdapter();
            DataTable dataTable = qlTT.GetData();
            dgvQLTinTuc.DataSource = dataTable;
        }
        private void TinTuc_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'doan_laptop.QLTinTuc' table. You can move, or remove it, as needed.
            this.qLTinTucTableAdapter.Fill(this.doan_laptop.QLTinTuc);

        }
    }
}
