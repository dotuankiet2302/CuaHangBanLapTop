namespace App_BanLaptop.Forms
{
    partial class QL_KhachHang
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNgaySinh = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbHienThiMK = new System.Windows.Forms.CheckBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Xoa = new System.Windows.Forms.PictureBox();
            this.Sua = new System.Windows.Forms.PictureBox();
            this.Them = new System.Windows.Forms.PictureBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMakh = new System.Windows.Forms.TextBox();
            this.radioButtonNu = new System.Windows.Forms.RadioButton();
            this.radioButtonNam = new System.Windows.Forms.RadioButton();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtTenkh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtMaTinh = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvKH = new System.Windows.Forms.DataGridView();
            this.cboTimKiem = new System.Windows.Forms.ComboBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qLKhachHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.doan_laptop = new App_BanLaptop.doan_laptop();
            this.khachhangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.khachhangTableAdapter = new App_BanLaptop.doan_laptopTableAdapters.khachhangTableAdapter();
            this.tableAdapterManager = new App_BanLaptop.doan_laptopTableAdapters.TableAdapterManager();
            this.qLKhachHangTableAdapter = new App_BanLaptop.doan_laptopTableAdapters.QLKhachHangTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.Xoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Them)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLKhachHangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.doan_laptop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.khachhangBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(832, 13);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(99, 46);
            this.btnSearch.TabIndex = 69;
            this.btnSearch.Text = "TÌM KIẾM";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(318, 13);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.txtTimKiem.Multiline = true;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(483, 41);
            this.txtTimKiem.TabIndex = 80;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(625, 78);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(208, 22);
            this.txtEmail.TabIndex = 128;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(517, 77);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(68, 22);
            this.label10.TabIndex = 127;
            this.label10.Text = "Email: ";
            // 
            // txtNgaySinh
            // 
            this.txtNgaySinh.Location = new System.Drawing.Point(237, 150);
            this.txtNgaySinh.Margin = new System.Windows.Forms.Padding(4);
            this.txtNgaySinh.Name = "txtNgaySinh";
            this.txtNgaySinh.Size = new System.Drawing.Size(208, 22);
            this.txtNgaySinh.TabIndex = 126;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(91, 149);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 22);
            this.label9.TabIndex = 125;
            this.label9.Text = "Ngày Sinh: ";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(622, 182);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(211, 22);
            this.txtUserName.TabIndex = 124;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(510, 181);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 22);
            this.label8.TabIndex = 123;
            this.label8.Text = "Tài Khoản: ";
            // 
            // cbHienThiMK
            // 
            this.cbHienThiMK.AutoSize = true;
            this.cbHienThiMK.Location = new System.Drawing.Point(625, 242);
            this.cbHienThiMK.Margin = new System.Windows.Forms.Padding(4);
            this.cbHienThiMK.Name = "cbHienThiMK";
            this.cbHienThiMK.Size = new System.Drawing.Size(137, 20);
            this.cbHienThiMK.TabIndex = 122;
            this.cbHienThiMK.Text = "Hiển Thị Mật Khẩu";
            this.cbHienThiMK.UseVisualStyleBackColor = true;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(622, 215);
            this.txtPass.Margin = new System.Windows.Forms.Padding(4);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(211, 22);
            this.txtPass.TabIndex = 121;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(510, 214);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 22);
            this.label7.TabIndex = 120;
            this.label7.Text = "Mật Khẩu: ";
            // 
            // Xoa
            // 
            this.Xoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Xoa.Image = global::App_BanLaptop.Properties.Resources.xoa;
            this.Xoa.Location = new System.Drawing.Point(877, 215);
            this.Xoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Xoa.Name = "Xoa";
            this.Xoa.Size = new System.Drawing.Size(54, 45);
            this.Xoa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Xoa.TabIndex = 119;
            this.Xoa.TabStop = false;
            // 
            // Sua
            // 
            this.Sua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Sua.Image = global::App_BanLaptop.Properties.Resources.sua;
            this.Sua.Location = new System.Drawing.Point(877, 150);
            this.Sua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Sua.Name = "Sua";
            this.Sua.Size = new System.Drawing.Size(54, 54);
            this.Sua.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Sua.TabIndex = 118;
            this.Sua.TabStop = false;
            // 
            // Them
            // 
            this.Them.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Them.Image = global::App_BanLaptop.Properties.Resources.them;
            this.Them.Location = new System.Drawing.Point(877, 88);
            this.Them.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Them.Name = "Them";
            this.Them.Size = new System.Drawing.Size(54, 48);
            this.Them.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Them.TabIndex = 117;
            this.Them.TabStop = false;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(625, 114);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(208, 22);
            this.txtAddress.TabIndex = 116;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(514, 113);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 22);
            this.label5.TabIndex = 115;
            this.label5.Text = "Địa chỉ:";
            // 
            // txtMakh
            // 
            this.txtMakh.Location = new System.Drawing.Point(237, 77);
            this.txtMakh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMakh.Name = "txtMakh";
            this.txtMakh.Size = new System.Drawing.Size(208, 22);
            this.txtMakh.TabIndex = 114;
            // 
            // radioButtonNu
            // 
            this.radioButtonNu.AutoSize = true;
            this.radioButtonNu.Location = new System.Drawing.Point(345, 184);
            this.radioButtonNu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonNu.Name = "radioButtonNu";
            this.radioButtonNu.Size = new System.Drawing.Size(45, 20);
            this.radioButtonNu.TabIndex = 113;
            this.radioButtonNu.TabStop = true;
            this.radioButtonNu.Text = "Nữ";
            this.radioButtonNu.UseVisualStyleBackColor = true;
            // 
            // radioButtonNam
            // 
            this.radioButtonNam.AutoSize = true;
            this.radioButtonNam.Location = new System.Drawing.Point(237, 184);
            this.radioButtonNam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonNam.Name = "radioButtonNam";
            this.radioButtonNam.Size = new System.Drawing.Size(57, 20);
            this.radioButtonNam.TabIndex = 112;
            this.radioButtonNam.TabStop = true;
            this.radioButtonNam.Text = "Nam";
            this.radioButtonNam.UseVisualStyleBackColor = true;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(237, 215);
            this.txtPhone.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(208, 22);
            this.txtPhone.TabIndex = 111;
            // 
            // txtTenkh
            // 
            this.txtTenkh.Location = new System.Drawing.Point(237, 114);
            this.txtTenkh.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenkh.Name = "txtTenkh";
            this.txtTenkh.Size = new System.Drawing.Size(208, 22);
            this.txtTenkh.TabIndex = 110;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(91, 212);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 22);
            this.label4.TabIndex = 109;
            this.label4.Text = "Điện thoại :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(91, 182);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 22);
            this.label3.TabIndex = 108;
            this.label3.Text = "Giới tính :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(87, 113);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 22);
            this.label2.TabIndex = 107;
            this.label2.Text = "Tên Khách Hàng:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(91, 77);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(143, 22);
            this.label12.TabIndex = 106;
            this.label12.Text = "Mã Khách Hàng:";
            // 
            // txtMaTinh
            // 
            this.txtMaTinh.Location = new System.Drawing.Point(625, 150);
            this.txtMaTinh.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaTinh.Name = "txtMaTinh";
            this.txtMaTinh.Size = new System.Drawing.Size(208, 22);
            this.txtMaTinh.TabIndex = 131;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(510, 150);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 22);
            this.label1.TabIndex = 130;
            this.label1.Text = "Mã Tỉnh: ";
            // 
            // dgvKH
            // 
            this.dgvKH.AutoGenerateColumns = false;
            this.dgvKH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.dgvKH.DataSource = this.qLKhachHangBindingSource;
            this.dgvKH.Location = new System.Drawing.Point(25, 291);
            this.dgvKH.Name = "dgvKH";
            this.dgvKH.RowHeadersWidth = 51;
            this.dgvKH.RowTemplate.Height = 24;
            this.dgvKH.Size = new System.Drawing.Size(1025, 242);
            this.dgvKH.TabIndex = 131;
            // 
            // cboTimKiem
            // 
            this.cboTimKiem.FormattingEnabled = true;
            this.cboTimKiem.Items.AddRange(new object[] {
            "Mã Khách Hàng",
            "Tên Khách Hàng"});
            this.cboTimKiem.Location = new System.Drawing.Point(102, 13);
            this.cboTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.cboTimKiem.Name = "cboTimKiem";
            this.cboTimKiem.Size = new System.Drawing.Size(192, 24);
            this.cboTimKiem.TabIndex = 132;
            this.cboTimKiem.Text = "Mã Khách Hàng";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MAKH";
            this.dataGridViewTextBoxColumn1.HeaderText = "MAKH";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "HOTEN";
            this.dataGridViewTextBoxColumn2.HeaderText = "HOTEN";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "NGAYSINH";
            this.dataGridViewTextBoxColumn3.HeaderText = "NGAYSINH";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "GIOITINH";
            this.dataGridViewTextBoxColumn4.HeaderText = "GIOITINH";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "DIENTHOAI";
            this.dataGridViewTextBoxColumn5.HeaderText = "DIENTHOAI";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "TAIKHOAN";
            this.dataGridViewTextBoxColumn6.HeaderText = "TAIKHOAN";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 125;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "MATKHAU";
            this.dataGridViewTextBoxColumn7.HeaderText = "MATKHAU";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 125;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "EMAIL";
            this.dataGridViewTextBoxColumn8.HeaderText = "EMAIL";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 125;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "DIACHI";
            this.dataGridViewTextBoxColumn9.HeaderText = "DIACHI";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 125;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "MATINH";
            this.dataGridViewTextBoxColumn10.HeaderText = "MATINH";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.Width = 125;
            // 
            // qLKhachHangBindingSource
            // 
            this.qLKhachHangBindingSource.DataMember = "QLKhachHang";
            this.qLKhachHangBindingSource.DataSource = this.doan_laptop;
            // 
            // doan_laptop
            // 
            this.doan_laptop.DataSetName = "doan_laptop";
            this.doan_laptop.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // khachhangBindingSource
            // 
            this.khachhangBindingSource.DataMember = "khachhang";
            this.khachhangBindingSource.DataSource = this.doan_laptop;
            // 
            // khachhangTableAdapter
            // 
            this.khachhangTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.chitietdonhangTableAdapter = null;
            this.tableAdapterManager.donhangTableAdapter = null;
            this.tableAdapterManager.hangmayTableAdapter = null;
            this.tableAdapterManager.khachhangTableAdapter = this.khachhangTableAdapter;
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
            // qLKhachHangTableAdapter
            // 
            this.qLKhachHangTableAdapter.ClearBeforeFill = true;
            // 
            // QL_KhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 580);
            this.Controls.Add(this.cboTimKiem);
            this.Controls.Add(this.dgvKH);
            this.Controls.Add(this.txtMaTinh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtNgaySinh);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbHienThiMK);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Xoa);
            this.Controls.Add(this.Sua);
            this.Controls.Add(this.Them);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMakh);
            this.Controls.Add(this.radioButtonNu);
            this.Controls.Add(this.radioButtonNam);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtTenkh);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnSearch);
            this.Name = "QL_KhachHang";
            this.Text = "QL_KhachHang";
            this.Load += new System.EventHandler(this.QL_KhachHang_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.Xoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Them)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLKhachHangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.doan_laptop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.khachhangBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNgaySinh;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cbHienThiMK;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox Xoa;
        private System.Windows.Forms.PictureBox Sua;
        private System.Windows.Forms.PictureBox Them;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMakh;
        private System.Windows.Forms.RadioButton radioButtonNu;
        private System.Windows.Forms.RadioButton radioButtonNam;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtTenkh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label12;
        private doan_laptop doan_laptop;
        private System.Windows.Forms.BindingSource khachhangBindingSource;
        private doan_laptopTableAdapters.khachhangTableAdapter khachhangTableAdapter;
        private doan_laptopTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingSource qLKhachHangBindingSource;
        private doan_laptopTableAdapters.QLKhachHangTableAdapter qLKhachHangTableAdapter;
        private System.Windows.Forms.TextBox txtMaTinh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.ComboBox cboTimKiem;
    }
}