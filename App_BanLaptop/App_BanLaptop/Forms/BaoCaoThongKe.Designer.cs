namespace App_BanLaptop.Forms
{
    partial class BaoCaoThongKe
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
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rdoMacDinh = new System.Windows.Forms.RadioButton();
            this.rdoTheoNgay = new System.Windows.Forms.RadioButton();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.dtpNgayKT = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayBD = new System.Windows.Forms.DateTimePicker();
            this.doan_laptop = new App_BanLaptop.doan_laptop();
            this.chitietdonhangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chitietdonhangTableAdapter = new App_BanLaptop.doan_laptopTableAdapters.chitietdonhangTableAdapter();
            this.tableAdapterManager = new App_BanLaptop.doan_laptopTableAdapters.TableAdapterManager();
            this.thongKeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.thongKeTableAdapter = new App_BanLaptop.doan_laptopTableAdapters.ThongKeTableAdapter();
            this.tongThongKeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tongThongKeTableAdapter = new App_BanLaptop.doan_laptopTableAdapters.TongThongKeTableAdapter();
            this.dgvSoLuong_DoanhThu = new System.Windows.Forms.DataGridView();
            this.dgvThongKe = new System.Windows.Forms.DataGridView();
            this.Xuat = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.doan_laptop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chitietdonhangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thongKeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tongThongKeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoLuong_DoanhThu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Xuat)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(409, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 36;
            this.label6.Text = "Đến ngày";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(89, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 35;
            this.label5.Text = "Từ ngày";
            // 
            // rdoMacDinh
            // 
            this.rdoMacDinh.AutoSize = true;
            this.rdoMacDinh.Checked = true;
            this.rdoMacDinh.Location = new System.Drawing.Point(572, 66);
            this.rdoMacDinh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoMacDinh.Name = "rdoMacDinh";
            this.rdoMacDinh.Size = new System.Drawing.Size(117, 20);
            this.rdoMacDinh.TabIndex = 34;
            this.rdoMacDinh.TabStop = true;
            this.rdoMacDinh.Text = "Theo mặc định";
            this.rdoMacDinh.UseVisualStyleBackColor = true;
            // 
            // rdoTheoNgay
            // 
            this.rdoTheoNgay.AutoSize = true;
            this.rdoTheoNgay.Location = new System.Drawing.Point(412, 66);
            this.rdoTheoNgay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rdoTheoNgay.Name = "rdoTheoNgay";
            this.rdoTheoNgay.Size = new System.Drawing.Size(93, 20);
            this.rdoTheoNgay.TabIndex = 33;
            this.rdoTheoNgay.TabStop = true;
            this.rdoTheoNgay.Text = "Theo ngày";
            this.rdoTheoNgay.UseVisualStyleBackColor = true;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(752, 12);
            this.btnThongKe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(92, 43);
            this.btnThongKe.TabIndex = 32;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            // 
            // dtpNgayKT
            // 
            this.dtpNgayKT.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayKT.Location = new System.Drawing.Point(492, 20);
            this.dtpNgayKT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpNgayKT.Name = "dtpNgayKT";
            this.dtpNgayKT.Size = new System.Drawing.Size(200, 22);
            this.dtpNgayKT.TabIndex = 31;
            // 
            // dtpNgayBD
            // 
            this.dtpNgayBD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayBD.Location = new System.Drawing.Point(178, 20);
            this.dtpNgayBD.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpNgayBD.Name = "dtpNgayBD";
            this.dtpNgayBD.Size = new System.Drawing.Size(200, 22);
            this.dtpNgayBD.TabIndex = 30;
            // 
            // doan_laptop
            // 
            this.doan_laptop.DataSetName = "doan_laptop";
            this.doan_laptop.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // chitietdonhangBindingSource
            // 
            this.chitietdonhangBindingSource.DataMember = "chitietdonhang";
            this.chitietdonhangBindingSource.DataSource = this.doan_laptop;
            // 
            // chitietdonhangTableAdapter
            // 
            this.chitietdonhangTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.chitietdonhangTableAdapter = this.chitietdonhangTableAdapter;
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
            // thongKeBindingSource
            // 
            this.thongKeBindingSource.DataMember = "ThongKe";
            this.thongKeBindingSource.DataSource = this.doan_laptop;
            // 
            // thongKeTableAdapter
            // 
            this.thongKeTableAdapter.ClearBeforeFill = true;
            // 
            // tongThongKeBindingSource
            // 
            this.tongThongKeBindingSource.DataMember = "TongThongKe";
            this.tongThongKeBindingSource.DataSource = this.doan_laptop;
            // 
            // tongThongKeTableAdapter
            // 
            this.tongThongKeTableAdapter.ClearBeforeFill = true;
            // 
            // dgvSoLuong_DoanhThu
            // 
            this.dgvSoLuong_DoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSoLuong_DoanhThu.Location = new System.Drawing.Point(84, 421);
            this.dgvSoLuong_DoanhThu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvSoLuong_DoanhThu.Name = "dgvSoLuong_DoanhThu";
            this.dgvSoLuong_DoanhThu.RowHeadersWidth = 51;
            this.dgvSoLuong_DoanhThu.RowTemplate.Height = 24;
            this.dgvSoLuong_DoanhThu.Size = new System.Drawing.Size(435, 127);
            this.dgvSoLuong_DoanhThu.TabIndex = 38;
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKe.Location = new System.Drawing.Point(84, 101);
            this.dgvThongKe.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.RowHeadersWidth = 51;
            this.dgvThongKe.RowTemplate.Height = 24;
            this.dgvThongKe.Size = new System.Drawing.Size(760, 315);
            this.dgvThongKe.TabIndex = 37;
            // 
            // Xuat
            // 
            this.Xuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Xuat.Image = global::App_BanLaptop.Properties.Resources.xuat;
            this.Xuat.Location = new System.Drawing.Point(874, 12);
            this.Xuat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Xuat.Name = "Xuat";
            this.Xuat.Size = new System.Drawing.Size(54, 54);
            this.Xuat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Xuat.TabIndex = 137;
            this.Xuat.TabStop = false;
            // 
            // BaoCaoThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 566);
            this.Controls.Add(this.Xuat);
            this.Controls.Add(this.dgvSoLuong_DoanhThu);
            this.Controls.Add(this.dgvThongKe);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rdoMacDinh);
            this.Controls.Add(this.rdoTheoNgay);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.dtpNgayKT);
            this.Controls.Add(this.dtpNgayBD);
            this.Name = "BaoCaoThongKe";
            this.Text = "Báo Cáo Thống Kê";
            this.Load += new System.EventHandler(this.BaoCaoThongKe_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.doan_laptop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chitietdonhangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thongKeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tongThongKeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSoLuong_DoanhThu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Xuat)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdoMacDinh;
        private System.Windows.Forms.RadioButton rdoTheoNgay;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.DateTimePicker dtpNgayKT;
        private System.Windows.Forms.DateTimePicker dtpNgayBD;
        private doan_laptop doan_laptop;
        private System.Windows.Forms.BindingSource chitietdonhangBindingSource;
        private doan_laptopTableAdapters.chitietdonhangTableAdapter chitietdonhangTableAdapter;
        private doan_laptopTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource thongKeBindingSource;
        private doan_laptopTableAdapters.ThongKeTableAdapter thongKeTableAdapter;
        private System.Windows.Forms.BindingSource tongThongKeBindingSource;
        private doan_laptopTableAdapters.TongThongKeTableAdapter tongThongKeTableAdapter;
        private System.Windows.Forms.DataGridView dgvSoLuong_DoanhThu;
        private System.Windows.Forms.DataGridView dgvThongKe;
        private System.Windows.Forms.PictureBox Xuat;
    }
}