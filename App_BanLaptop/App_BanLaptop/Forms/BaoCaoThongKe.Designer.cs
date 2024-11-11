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
            this.dgvThongKe = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tongThongKeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tongThongKeTableAdapter = new App_BanLaptop.doan_laptopTableAdapters.TongThongKeTableAdapter();
            this.tongThongKeDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.doan_laptop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chitietdonhangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thongKeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tongThongKeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tongThongKeDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(666, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 36;
            this.label6.Text = "Đến ngày";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(176, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 35;
            this.label5.Text = "Từ ngày";
            // 
            // rdoMacDinh
            // 
            this.rdoMacDinh.AutoSize = true;
            this.rdoMacDinh.Checked = true;
            this.rdoMacDinh.Location = new System.Drawing.Point(617, 75);
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
            this.rdoTheoNgay.Location = new System.Drawing.Point(457, 75);
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
            this.btnThongKe.Location = new System.Drawing.Point(529, 20);
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
            this.dtpNgayKT.Location = new System.Drawing.Point(749, 31);
            this.dtpNgayKT.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpNgayKT.Name = "dtpNgayKT";
            this.dtpNgayKT.Size = new System.Drawing.Size(200, 22);
            this.dtpNgayKT.TabIndex = 31;
            // 
            // dtpNgayBD
            // 
            this.dtpNgayBD.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayBD.Location = new System.Drawing.Point(265, 31);
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
            // dgvThongKe
            // 
            this.dgvThongKe.AutoGenerateColumns = false;
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgvThongKe.DataSource = this.thongKeBindingSource;
            this.dgvThongKe.Location = new System.Drawing.Point(24, 109);
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.RowHeadersWidth = 51;
            this.dgvThongKe.RowTemplate.Height = 24;
            this.dgvThongKe.Size = new System.Drawing.Size(935, 289);
            this.dgvThongKe.TabIndex = 37;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "TENLAP";
            this.dataGridViewTextBoxColumn1.HeaderText = "TENLAP";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "GIABAN";
            this.dataGridViewTextBoxColumn2.HeaderText = "GIABAN";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SOLUONG";
            this.dataGridViewTextBoxColumn3.HeaderText = "SOLUONG";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "NGAYDAT";
            this.dataGridViewTextBoxColumn4.HeaderText = "NGAYDAT";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "TONGTIEN";
            this.dataGridViewTextBoxColumn5.HeaderText = "TONGTIEN";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 125;
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
            // tongThongKeDataGridView
            // 
            this.tongThongKeDataGridView.AutoGenerateColumns = false;
            this.tongThongKeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tongThongKeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.tongThongKeDataGridView.DataSource = this.tongThongKeBindingSource;
            this.tongThongKeDataGridView.Location = new System.Drawing.Point(24, 411);
            this.tongThongKeDataGridView.Name = "tongThongKeDataGridView";
            this.tongThongKeDataGridView.RowHeadersWidth = 51;
            this.tongThongKeDataGridView.RowTemplate.Height = 24;
            this.tongThongKeDataGridView.Size = new System.Drawing.Size(406, 143);
            this.tongThongKeDataGridView.TabIndex = 37;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "TONGSOLUONG";
            this.dataGridViewTextBoxColumn6.HeaderText = "TONGSOLUONG";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 125;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "TONGDOANHTHU";
            this.dataGridViewTextBoxColumn7.HeaderText = "TONGDOANHTHU";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 125;
            // 
            // BaoCaoThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 566);
            this.Controls.Add(this.tongThongKeDataGridView);
            this.Controls.Add(this.dgvThongKe);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rdoMacDinh);
            this.Controls.Add(this.rdoTheoNgay);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.dtpNgayKT);
            this.Controls.Add(this.dtpNgayBD);
            this.Name = "BaoCaoThongKe";
            this.Text = "BaoCaoThongKe";
            this.Load += new System.EventHandler(this.BaoCaoThongKe_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.doan_laptop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chitietdonhangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thongKeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tongThongKeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tongThongKeDataGridView)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvThongKe;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.BindingSource tongThongKeBindingSource;
        private doan_laptopTableAdapters.TongThongKeTableAdapter tongThongKeTableAdapter;
        private System.Windows.Forms.DataGridView tongThongKeDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
    }
}