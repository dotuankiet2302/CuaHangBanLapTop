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
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doan_laptop = new App_BanLaptop.doan_laptop();
            this.qLTinTucBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLTinTucTableAdapter = new App_BanLaptop.doan_laptopTableAdapters.QLTinTucTableAdapter();
            this.tableAdapterManager = new App_BanLaptop.doan_laptopTableAdapters.TableAdapterManager();
            this.dgvTinTuc = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtMaTin = new UC_RequiredTextBox.txtKhongDeTrong();
            this.txtTieuDe = new UC_RequiredTextBox.txtKhongDeTrong();
            this.txtNoiDung = new UC_RequiredTextBox.txtKhongDeTrong();
            this.txtNgayDang = new UC_RequiredTextBox.txtKhongDeTrong();
            this.txtMaLoaiTin = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.picHInhAnh = new System.Windows.Forms.PictureBox();
            this.Xuat = new System.Windows.Forms.PictureBox();
            this.In = new System.Windows.Forms.PictureBox();
            this.Xoa = new System.Windows.Forms.PictureBox();
            this.Sua = new System.Windows.Forms.PictureBox();
            this.Them = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.doan_laptop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTinTucBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTinTuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHInhAnh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Xuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.In)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Xoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Them)).BeginInit();
            this.SuspendLayout();
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
            // doan_laptop
            // 
            this.doan_laptop.DataSetName = "doan_laptop";
            this.doan_laptop.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // qLTinTucBindingSource
            // 
            this.qLTinTucBindingSource.DataMember = "QLTinTuc";
            this.qLTinTucBindingSource.DataSource = this.doan_laptop;
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
            // dgvTinTuc
            // 
            this.dgvTinTuc.AutoGenerateColumns = false;
            this.dgvTinTuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTinTuc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12});
            this.dgvTinTuc.DataSource = this.qLTinTucBindingSource;
            this.dgvTinTuc.Location = new System.Drawing.Point(42, 245);
            this.dgvTinTuc.Name = "dgvTinTuc";
            this.dgvTinTuc.RowHeadersWidth = 51;
            this.dgvTinTuc.RowTemplate.Height = 24;
            this.dgvTinTuc.Size = new System.Drawing.Size(1036, 220);
            this.dgvTinTuc.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "MATIN";
            this.dataGridViewTextBoxColumn7.HeaderText = "MATIN";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 125;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "TIEUDE";
            this.dataGridViewTextBoxColumn8.HeaderText = "TIEUDE";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 125;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "NOIDUNG";
            this.dataGridViewTextBoxColumn9.HeaderText = "NOIDUNG";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 125;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "HINH";
            this.dataGridViewTextBoxColumn10.HeaderText = "HINH";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 125;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "NGAYDANG";
            this.dataGridViewTextBoxColumn11.HeaderText = "NGAYDANG";
            this.dataGridViewTextBoxColumn11.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 125;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "TLTIN";
            this.dataGridViewTextBoxColumn12.HeaderText = "TLTIN";
            this.dataGridViewTextBoxColumn12.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.Width = 125;
            // 
            // txtMaTin
            // 
            this.txtMaTin.BackColor = System.Drawing.Color.LightPink;
            this.txtMaTin.Location = new System.Drawing.Point(138, 9);
            this.txtMaTin.Name = "txtMaTin";
            this.txtMaTin.Size = new System.Drawing.Size(100, 22);
            this.txtMaTin.TabIndex = 2;
            // 
            // txtTieuDe
            // 
            this.txtTieuDe.BackColor = System.Drawing.Color.LightPink;
            this.txtTieuDe.Location = new System.Drawing.Point(138, 42);
            this.txtTieuDe.Name = "txtTieuDe";
            this.txtTieuDe.Size = new System.Drawing.Size(100, 22);
            this.txtTieuDe.TabIndex = 3;
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.BackColor = System.Drawing.Color.LightPink;
            this.txtNoiDung.Location = new System.Drawing.Point(138, 70);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(100, 22);
            this.txtNoiDung.TabIndex = 4;
            // 
            // txtNgayDang
            // 
            this.txtNgayDang.BackColor = System.Drawing.Color.LightPink;
            this.txtNgayDang.Location = new System.Drawing.Point(138, 100);
            this.txtNgayDang.Name = "txtNgayDang";
            this.txtNgayDang.Size = new System.Drawing.Size(100, 22);
            this.txtNgayDang.TabIndex = 5;
            // 
            // txtMaLoaiTin
            // 
            this.txtMaLoaiTin.FormattingEnabled = true;
            this.txtMaLoaiTin.Items.AddRange(new object[] {
            "TIN TỨC MỚI NHẤT",
            "TIN KHUYẾN MÃI",
            "TIN TỨC KHÁC"});
            this.txtMaLoaiTin.Location = new System.Drawing.Point(355, 9);
            this.txtMaLoaiTin.Name = "txtMaLoaiTin";
            this.txtMaLoaiTin.Size = new System.Drawing.Size(121, 24);
            this.txtMaLoaiTin.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Mã tin";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Tiêu đề";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Nội dung";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Ngày đăng";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(257, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Mã loại tin";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(257, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 16);
            this.label10.TabIndex = 12;
            this.label10.Text = "Hình ảnh";
            // 
            // picHInhAnh
            // 
            this.picHInhAnh.ErrorImage = global::App_BanLaptop.Properties.Resources.errorImage;
            this.picHInhAnh.Location = new System.Drawing.Point(355, 42);
            this.picHInhAnh.Name = "picHInhAnh";
            this.picHInhAnh.Size = new System.Drawing.Size(270, 180);
            this.picHInhAnh.TabIndex = 94;
            this.picHInhAnh.TabStop = false;
            // 
            // Xuat
            // 
            this.Xuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Xuat.Image = global::App_BanLaptop.Properties.Resources.xuat;
            this.Xuat.Location = new System.Drawing.Point(689, 185);
            this.Xuat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Xuat.Name = "Xuat";
            this.Xuat.Size = new System.Drawing.Size(44, 39);
            this.Xuat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Xuat.TabIndex = 143;
            this.Xuat.TabStop = false;
            // 
            // In
            // 
            this.In.Cursor = System.Windows.Forms.Cursors.Hand;
            this.In.Image = global::App_BanLaptop.Properties.Resources.In;
            this.In.Location = new System.Drawing.Point(689, 141);
            this.In.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.In.Name = "In";
            this.In.Size = new System.Drawing.Size(44, 40);
            this.In.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.In.TabIndex = 142;
            this.In.TabStop = false;
            // 
            // Xoa
            // 
            this.Xoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Xoa.Image = global::App_BanLaptop.Properties.Resources.xoa;
            this.Xoa.Location = new System.Drawing.Point(688, 97);
            this.Xoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Xoa.Name = "Xoa";
            this.Xoa.Size = new System.Drawing.Size(43, 40);
            this.Xoa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Xoa.TabIndex = 141;
            this.Xoa.TabStop = false;
            // 
            // Sua
            // 
            this.Sua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Sua.Image = global::App_BanLaptop.Properties.Resources.sua;
            this.Sua.Location = new System.Drawing.Point(689, 55);
            this.Sua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Sua.Name = "Sua";
            this.Sua.Size = new System.Drawing.Size(42, 38);
            this.Sua.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Sua.TabIndex = 140;
            this.Sua.TabStop = false;
            // 
            // Them
            // 
            this.Them.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Them.Image = global::App_BanLaptop.Properties.Resources.them;
            this.Them.Location = new System.Drawing.Point(689, 12);
            this.Them.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Them.Name = "Them";
            this.Them.Size = new System.Drawing.Size(42, 39);
            this.Them.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Them.TabIndex = 139;
            this.Them.TabStop = false;
            // 
            // TinTuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1396, 594);
            this.Controls.Add(this.Xuat);
            this.Controls.Add(this.In);
            this.Controls.Add(this.Xoa);
            this.Controls.Add(this.Sua);
            this.Controls.Add(this.Them);
            this.Controls.Add(this.picHInhAnh);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMaLoaiTin);
            this.Controls.Add(this.txtNgayDang);
            this.Controls.Add(this.txtNoiDung);
            this.Controls.Add(this.txtTieuDe);
            this.Controls.Add(this.txtMaTin);
            this.Controls.Add(this.dgvTinTuc);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TinTuc";
            this.Text = "Tin Tức";
            this.Load += new System.EventHandler(this.TinTuc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.doan_laptop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLTinTucBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTinTuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHInhAnh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Xuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.In)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Xoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Them)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private doan_laptop doan_laptop;
        private BindingSource qLTinTucBindingSource;
        private doan_laptopTableAdapters.QLTinTucTableAdapter qLTinTucTableAdapter;
        private doan_laptopTableAdapters.TableAdapterManager tableAdapterManager;
        private DataGridView dgvTinTuc;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private UC_RequiredTextBox.txtKhongDeTrong txtMaTin;
        private UC_RequiredTextBox.txtKhongDeTrong txtTieuDe;
        private UC_RequiredTextBox.txtKhongDeTrong txtNoiDung;
        private UC_RequiredTextBox.txtKhongDeTrong txtNgayDang;
        private ComboBox txtMaLoaiTin;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label10;
        private PictureBox picHInhAnh;
        private PictureBox Xuat;
        private PictureBox In;
        private PictureBox Xoa;
        private PictureBox Sua;
        private PictureBox Them;
    }
}