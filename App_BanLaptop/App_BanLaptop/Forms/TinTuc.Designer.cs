using System.Windows.Forms;

namespace App_BanLaptop.Forms
{
    partial class TinTuc
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtMaTin = new System.Windows.Forms.TextBox();
            this.txtNoiDung = new System.Windows.Forms.TextBox();
            this.txtTieuDe = new System.Windows.Forms.TextBox();
            this.txtNgayDang = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.In = new System.Windows.Forms.PictureBox();
            this.Xoa = new System.Windows.Forms.PictureBox();
            this.Sua = new System.Windows.Forms.PictureBox();
            this.Them = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picHInhAnh = new System.Windows.Forms.PictureBox();
            this.cboTimKiem = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.dgvQLTinTuc = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qLTinTucBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.doan_laptop = new App_BanLaptop.doan_laptop();
            this.qLTinTucTableAdapter = new App_BanLaptop.doan_laptopTableAdapters.QLTinTucTableAdapter();
            this.tableAdapterManager = new App_BanLaptop.doan_laptopTableAdapters.TableAdapterManager();
            this.txtMaLoaiTin = new System.Windows.Forms.ComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.In)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Xoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Them)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHInhAnh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLTinTuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTinTucBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doan_laptop)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMaTin
            // 
            this.txtMaTin.Location = new System.Drawing.Point(122, 112);
            this.txtMaTin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMaTin.Name = "txtMaTin";
            this.txtMaTin.Size = new System.Drawing.Size(121, 20);
            this.txtMaTin.TabIndex = 20;
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.Location = new System.Drawing.Point(472, 112);
            this.txtNoiDung.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(335, 20);
            this.txtNoiDung.TabIndex = 18;
            // 
            // txtTieuDe
            // 
            this.txtTieuDe.Location = new System.Drawing.Point(271, 112);
            this.txtTieuDe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTieuDe.Name = "txtTieuDe";
            this.txtTieuDe.Size = new System.Drawing.Size(175, 20);
            this.txtTieuDe.TabIndex = 17;
            // 
            // txtNgayDang
            // 
            this.txtNgayDang.Location = new System.Drawing.Point(272, 169);
            this.txtNgayDang.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNgayDang.Name = "txtNgayDang";
            this.txtNgayDang.Size = new System.Drawing.Size(121, 20);
            this.txtNgayDang.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(470, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 16);
            this.label13.TabIndex = 7;
            this.label13.Text = "Nội dung:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(269, 92);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 16);
            this.label12.TabIndex = 6;
            this.label12.Text = "Tiêu đề:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(269, 151);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 16);
            this.label9.TabIndex = 3;
            this.label9.Text = "Ngày đăng:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(118, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "Mã tin: ";
            // 
            // In
            // 
            this.In.Cursor = System.Windows.Forms.Cursors.Hand;
            this.In.Image = global::App_BanLaptop.Properties.Resources.In;
            this.In.Location = new System.Drawing.Point(953, 182);
            this.In.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.In.Name = "In";
            this.In.Size = new System.Drawing.Size(54, 45);
            this.In.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.In.TabIndex = 94;
            this.In.TabStop = false;
            // 
            // Xoa
            // 
            this.Xoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Xoa.Image = global::App_BanLaptop.Properties.Resources.xoa;
            this.Xoa.Location = new System.Drawing.Point(836, 182);
            this.Xoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Xoa.Name = "Xoa";
            this.Xoa.Size = new System.Drawing.Size(54, 45);
            this.Xoa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Xoa.TabIndex = 93;
            this.Xoa.TabStop = false;
            // 
            // Sua
            // 
            this.Sua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Sua.Image = global::App_BanLaptop.Properties.Resources.sua;
            this.Sua.Location = new System.Drawing.Point(953, 112);
            this.Sua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Sua.Name = "Sua";
            this.Sua.Size = new System.Drawing.Size(54, 54);
            this.Sua.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Sua.TabIndex = 92;
            this.Sua.TabStop = false;
            // 
            // Them
            // 
            this.Them.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Them.Image = global::App_BanLaptop.Properties.Resources.them;
            this.Them.Location = new System.Drawing.Point(836, 112);
            this.Them.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Them.Name = "Them";
            this.Them.Size = new System.Drawing.Size(54, 48);
            this.Them.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Them.TabIndex = 91;
            this.Them.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 95;
            this.label1.Text = "Mã loại tin: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(469, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 16);
            this.label2.TabIndex = 97;
            this.label2.Text = "Hình ảnh:";
            // 
            // picHInhAnh
            // 
            this.picHInhAnh.ErrorImage = global::App_BanLaptop.Properties.Resources.errorImage;
            this.picHInhAnh.Location = new System.Drawing.Point(537, 160);
            this.picHInhAnh.Name = "picHInhAnh";
            this.picHInhAnh.Size = new System.Drawing.Size(270, 180);
            this.picHInhAnh.TabIndex = 98;
            this.picHInhAnh.TabStop = false;
            // 
            // cboTimKiem
            // 
            this.cboTimKiem.FormattingEnabled = true;
            this.cboTimKiem.Items.AddRange(new object[] {
            "Tên Sản Phẩm",
            "Giá Bán"});
            this.cboTimKiem.Location = new System.Drawing.Point(99, 24);
            this.cboTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.cboTimKiem.Name = "cboTimKiem";
            this.cboTimKiem.Size = new System.Drawing.Size(174, 21);
            this.cboTimKiem.TabIndex = 101;
            this.cboTimKiem.Text = "Tên Sản Phẩm";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(898, 24);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(109, 42);
            this.btnTimKiem.TabIndex = 100;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(318, 24);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.txtTimKiem.Multiline = true;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(544, 41);
            this.txtTimKiem.TabIndex = 99;
            // 
            // dgvQLTinTuc
            // 
            this.dgvQLTinTuc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvQLTinTuc.AutoGenerateColumns = false;
            this.dgvQLTinTuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQLTinTuc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dgvQLTinTuc.DataSource = this.qLTinTucBindingSource;
            this.dgvQLTinTuc.Location = new System.Drawing.Point(12, 346);
            this.dgvQLTinTuc.Name = "dgvQLTinTuc";
            this.dgvQLTinTuc.RowHeadersWidth = 51;
            this.dgvQLTinTuc.RowTemplate.Height = 24;
            this.dgvQLTinTuc.Size = new System.Drawing.Size(1074, 220);
            this.dgvQLTinTuc.TabIndex = 102;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MATIN";
            this.dataGridViewTextBoxColumn1.HeaderText = "MATIN";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TIEUDE";
            this.dataGridViewTextBoxColumn2.HeaderText = "TIEUDE";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "NOIDUNG";
            this.dataGridViewTextBoxColumn3.HeaderText = "NOIDUNG";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "HINH";
            this.dataGridViewTextBoxColumn4.HeaderText = "HINH";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "NGAYDANG";
            this.dataGridViewTextBoxColumn5.HeaderText = "NGAYDANG";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "TLTIN";
            this.dataGridViewTextBoxColumn6.HeaderText = "TLTIN";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 125;
            // 
            // qLTinTucBindingSource
            // 
            this.qLTinTucBindingSource.DataMember = "QLTinTuc";
            this.qLTinTucBindingSource.DataSource = this.doan_laptop;
            // 
            // doan_laptop
            // 
            this.doan_laptop.DataSetName = "doan_laptop";
            this.doan_laptop.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // qLTinTucTableAdapter
            // 
            this.qLTinTucTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.chitietdonhangTableAdapter = null;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.donhangTableAdapter = null;
            this.tableAdapterManager.hangmayTableAdapter = null;
            this.tableAdapterManager.khachhangTableAdapter = null;
            this.tableAdapterManager.laptopTableAdapter = null;
            this.tableAdapterManager.loaitinTableAdapter = null;
            this.tableAdapterManager.nhasxTableAdapter = null;
            this.tableAdapterManager.phanquyenTableAdapter = null;
            this.tableAdapterManager.phuongTableAdapter = null;
            this.tableAdapterManager.QLKhachHangTableAdapter = null;
            this.tableAdapterManager.QLNhanVienTableAdapter = null;
            this.tableAdapterManager.quanTableAdapter = null;
            this.tableAdapterManager.tinhTableAdapter = null;
            this.tableAdapterManager.tinhtrangmayTableAdapter = null;
            this.tableAdapterManager.tinTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = App_BanLaptop.doan_laptopTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // txtMaLoaiTin
            // 
            this.txtMaLoaiTin.FormattingEnabled = true;
            this.txtMaLoaiTin.Items.AddRange(new object[] {
            "TIN TỨC MỚI NHẤT",
            "TIN KHUYẾN MẠI",
            "TIN TỨC KHÁC"});
            this.txtMaLoaiTin.Location = new System.Drawing.Point(122, 169);
            this.txtMaLoaiTin.Name = "txtMaLoaiTin";
            this.txtMaLoaiTin.Size = new System.Drawing.Size(121, 21);
            this.txtMaLoaiTin.TabIndex = 103;
            this.txtMaLoaiTin.Text = "TIN TỨC MỚI NHẤT";
            // 
            // TinTuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1047, 483);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "TinTuc";
            this.Text = "DatHang";
            this.Load += new System.EventHandler(this.TinTuc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.In)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Xoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Them)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHInhAnh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQLTinTuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTinTucBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doan_laptop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtMaTin;
        private System.Windows.Forms.TextBox txtNoiDung;
        private System.Windows.Forms.TextBox txtTieuDe;
        private System.Windows.Forms.TextBox txtNgayDang;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox In;
        private System.Windows.Forms.PictureBox Xoa;
        private System.Windows.Forms.PictureBox Sua;
        private System.Windows.Forms.PictureBox Them;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picHInhAnh;
        private System.Windows.Forms.ComboBox cboTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private doan_laptop doan_laptop;
        private System.Windows.Forms.BindingSource qLTinTucBindingSource;
        private doan_laptopTableAdapters.QLTinTucTableAdapter qLTinTucTableAdapter;
        private doan_laptopTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView dgvQLTinTuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.ComboBox txtMaLoaiTin;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}