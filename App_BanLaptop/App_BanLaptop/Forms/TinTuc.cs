using App_BanLaptop.doan_laptopTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace App_BanLaptop.Forms
{
    public partial class TinTuc : Form
    {
        private bool isEditing = false; 
        public TinTuc()
        {
            InitializeComponent();
            this.Load += TinTuc_Load1;
            this.dgvTinTuc.CellClick += DgvTinTuc_CellClick;
            this.Them.Click += Them_Click;
            this.Sua.Click += Sua_Click;
            this.Xoa.Click += Xoa_Click;
            this.picHInhAnh.Click += PicHInhAnh_Click;

            SetInitialState();
        }

        private void SetInitialState()
        {
            // Disable các controls nhập liệu
            picHInhAnh.Enabled = false;
            txtMaTin.Enabled = false;
            txtTieuDe.Enabled = false;
            txtNoiDung.Enabled = false;
            txtNgayDang.Enabled = false;
            txtMaLoaiTin.Enabled = false;

            // Đặt màu mờ cho nút Thêm và Sửa
            Them.Image = SetImageOpacity(Properties.Resources.them, 0.5f);
            Sua.Image = SetImageOpacity(Properties.Resources.sua, 0.5f);
            
            isEditing = false;
        }

        private void EnableEditingState()
        {
            // Enable các controls nhập liệu
            txtMaTin.Enabled = true;
            txtTieuDe.Enabled = true;
            txtNoiDung.Enabled = true;
            txtNgayDang.Enabled = true;
            txtMaLoaiTin.Enabled = true;
            picHInhAnh.Enabled = true;

            // Đặt lại màu bình thường cho nút đang được chọn
            if (isEditing)
            {
                Them.Image = Properties.Resources.them;
                Sua.Image = Properties.Resources.sua;
            }
        }

        private Bitmap SetImageOpacity(Image image, float opacity)
        {
            try
            {
                // Tạo một Bitmap mới từ ảnh gốc
                Bitmap bmp = new Bitmap(image.Width, image.Height);
                
                // Tạo ma trận màu để điều chỉnh độ trong suốt
                float[][] colorMatrix = {
                    new float[] {1, 0, 0, 0, 0},
                    new float[] {0, 1, 0, 0, 0},
                    new float[] {0, 0, 1, 0, 0},
                    new float[] {0, 0, 0, opacity, 0},
                    new float[] {0, 0, 0, 0, 1}
                };

                using (Graphics g = Graphics.FromImage(bmp))
                using (ImageAttributes attributes = new ImageAttributes())
                {
                    attributes.SetColorMatrix(new ColorMatrix(colorMatrix));
                    g.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height),
                        0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
                }

                return bmp;
            }
            catch
            {
                return (Bitmap)image;
            }
        }


        private void PicHInhAnh_Click(object sender, EventArgs e)
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
                    if (picHInhAnh.Image != null)
                    {
                        picHInhAnh.Image.Dispose();
                        picHInhAnh.Image = null;
                    }

                    // Tạo bản sao của hình ảnh mới
                    using (var sourceImage = Image.FromFile(openFileDialog.FileName))
                    {
                        picHInhAnh.Image = new Bitmap(sourceImage);
                        picHInhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
                    }

                    // Copy file vào thư mục Images
                    if (File.Exists(destinationPath))
                    {
                        // Đợi một chút để đảm bảo file đã được giải phóng
                        System.Threading.Thread.Sleep(100);
                        File.Delete(destinationPath);
                    }
                    File.Copy(openFileDialog.FileName, destinationPath);

                    picHInhAnh.Text = fileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi tải ảnh: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (picHInhAnh.Image != null)
            {
                picHInhAnh.Image.Dispose();
                picHInhAnh.Image = null;
            }
        }
        private void DgvTinTuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTinTuc.Rows[e.RowIndex];

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

                try
                {
                    // Giải phóng tài nguyên hình ảnh cũ
                    if (picHInhAnh.Image != null)
                    {
                        picHInhAnh.Image.Dispose();
                        picHInhAnh.Image = null;
                    }

                    // Load ảnh mới bằng cách tạo bản sao
                    string imagePath = Path.Combine(Application.StartupPath, "Images", images);
                    using (var sourceImage = Image.FromFile(imagePath))
                    {
                        picHInhAnh.Image = new Bitmap(sourceImage);
                        picHInhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    picHInhAnh.Text = images;
                }
                catch (Exception ex)
                {
                    try
                    {
                        if (picHInhAnh.Image != null)
                        {
                            picHInhAnh.Image.Dispose();
                            picHInhAnh.Image = null;
                        }

                        string errorImagePath = Path.Combine(Application.StartupPath, "Images", "errorImage.jpg");
                        using (var errorImage = Image.FromFile(errorImagePath))
                        {
                            picHInhAnh.Image = new Bitmap(errorImage);
                            picHInhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                        MessageBox.Show("Chưa có ảnh cho tin tức này!!!\n" + ex.Message);
                    }
                    catch
                    {
                        MessageBox.Show("Không thể tải ảnh mặc định!");
                    }
                }
            }
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
            if (!isEditing)
            {
                isEditing = true;
                EnableEditingState();
            }
            else
            {
                // Thực hiện cập nhật vào database
                try
                {
                    QLTinTucTableAdapter qlTT = new QLTinTucTableAdapter();
                    int maTin = int.Parse(txtMaTin.Text);
                    string tieuDe = txtTieuDe.Text;
                    string noiDung = txtNoiDung.Text;
                    string hinhAnh = picHInhAnh.Text;
                    string ngayDang = txtNgayDang.Text;
                    int maLoaiTin = GetMaLoaiTin();

                    qlTT.Sua(tieuDe, noiDung, hinhAnh, ngayDang, maLoaiTin, maTin);
                    loadTinTuc();
                    
                    SetInitialState();
                    MessageBox.Show("Cập nhật tin tức thành công");
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void Them_Click(object sender, EventArgs e)
        {
            if (!isEditing)
            {
                // Bắt đầu thêm mới
                isEditing = true;
                EnableEditingState();
                
                // Xóa trắng các controls
                txtMaTin.Clear();
                txtTieuDe.Clear();
                txtNoiDung.Clear();
                txtNgayDang.Clear();
                txtMaLoaiTin.Text = "";
                picHInhAnh.Image = null;
                picHInhAnh.Text = "";
            }
            else
            {
                // Thực hiện thêm vào database
                try
                {
                    QLTinTucTableAdapter qlTT = new QLTinTucTableAdapter();
                    int maTin = int.Parse(txtMaTin.Text);
                    string tieuDe = txtTieuDe.Text;
                    string noiDung = txtNoiDung.Text;
                    string hinhAnh = picHInhAnh.Text;
                    string ngayDang = txtNgayDang.Text;
                    int maLoaiTin = GetMaLoaiTin();

                    var existingRecord = qlTT.GetData().FirstOrDefault(kh => kh.MATIN == maTin);
                    if (existingRecord == null)
                    {
                        qlTT.Them(maTin, tieuDe, noiDung, hinhAnh, ngayDang, maLoaiTin);
                        loadTinTuc();
                        SetInitialState();
                        MessageBox.Show("Thêm tin tức thành công");
                        
                    }
                    else
                    {
                        MessageBox.Show("Mã tin đã tồn tại. Vui lòng chọn mã khác.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
        private int GetMaLoaiTin()
        {
            if (txtMaLoaiTin.Text == "TIN TỨC MỚI NHẤT")
                return 1;
            else if (txtMaLoaiTin.Text == "TIN KHUYẾN MẠI")
                return 2;
            else if (txtMaLoaiTin.Text == "TIN TỨC KHÁC")
                return 3;
            return 1; // Mặc định
        }
        private void TinTuc_Load1(object sender, EventArgs e)
        {
            loadTinTuc();
        }

        public void loadTinTuc()
        {
            QLTinTucTableAdapter qlTT = new QLTinTucTableAdapter();
            DataTable dataTable = qlTT.GetData();
            dgvTinTuc.DataSource = dataTable;
        }
        private void TinTuc_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'doan_laptop.QLTinTuc' table. You can move, or remove it, as needed.
            this.qLTinTucTableAdapter.Fill(this.doan_laptop.QLTinTuc);
            // TODO: This line of code loads data into the 'doan_laptop.QLTinTuc' table. You can move, or remove it, as needed.
            this.qLTinTucTableAdapter.Fill(this.doan_laptop.QLTinTuc);

        }
    }
}
