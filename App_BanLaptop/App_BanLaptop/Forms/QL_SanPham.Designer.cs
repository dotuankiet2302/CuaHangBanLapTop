namespace App_BanLaptop.Forms
{
    partial class QL_SanPham
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
            this.cboTimKiem = new System.Windows.Forms.ComboBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.txtMaTinhTrang = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaMH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nUDSoLuong = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenMH = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvSanPham = new System.Windows.Forms.DataGridView();
            this.Xoa = new System.Windows.Forms.PictureBox();
            this.Sua = new System.Windows.Forms.PictureBox();
            this.Them = new System.Windows.Forms.PictureBox();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNgayCapNhat = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMaHang = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMaNSX = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtGiaBan = new System.Windows.Forms.TextBox();
            this.picAnhBia = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nUDSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Xoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Them)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnhBia)).BeginInit();
            this.SuspendLayout();
            // 
            // cboTimKiem
            // 
            this.cboTimKiem.FormattingEnabled = true;
            this.cboTimKiem.Items.AddRange(new object[] {
            "Mã Mặt Hàng",
            "Tên Mặt Hàng"});
            this.cboTimKiem.Location = new System.Drawing.Point(34, 15);
            this.cboTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.cboTimKiem.Name = "cboTimKiem";
            this.cboTimKiem.Size = new System.Drawing.Size(201, 24);
            this.cboTimKiem.TabIndex = 81;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(925, 15);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(109, 42);
            this.btnTimKiem.TabIndex = 80;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(280, 15);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.txtTimKiem.Multiline = true;
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(612, 41);
            this.txtTimKiem.TabIndex = 79;
            // 
            // txtMaTinhTrang
            // 
            this.txtMaTinhTrang.Location = new System.Drawing.Point(157, 111);
            this.txtMaTinhTrang.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaTinhTrang.Name = "txtMaTinhTrang";
            this.txtMaTinhTrang.Size = new System.Drawing.Size(133, 22);
            this.txtMaTinhTrang.TabIndex = 75;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(32, 111);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 20);
            this.label6.TabIndex = 74;
            this.label6.Text = "Mã tình trạng:";
            // 
            // txtMaMH
            // 
            this.txtMaMH.Location = new System.Drawing.Point(157, 69);
            this.txtMaMH.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaMH.Name = "txtMaMH";
            this.txtMaMH.Size = new System.Drawing.Size(133, 22);
            this.txtMaMH.TabIndex = 71;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 20);
            this.label3.TabIndex = 70;
            this.label3.Text = "Mã Laptop:";
            // 
            // nUDSoLuong
            // 
            this.nUDSoLuong.Location = new System.Drawing.Point(471, 110);
            this.nUDSoLuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nUDSoLuong.Name = "nUDSoLuong";
            this.nUDSoLuong.Size = new System.Drawing.Size(135, 22);
            this.nUDSoLuong.TabIndex = 69;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(330, 110);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 68;
            this.label1.Text = "Số lượng tồn: ";
            // 
            // txtTenMH
            // 
            this.txtTenMH.Location = new System.Drawing.Point(740, 69);
            this.txtTenMH.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenMH.Name = "txtTenMH";
            this.txtTenMH.Size = new System.Drawing.Size(229, 22);
            this.txtTenMH.TabIndex = 66;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(32, 148);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 20);
            this.label5.TabIndex = 65;
            this.label5.Text = "Đơn giá bán :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(623, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 64;
            this.label2.Text = "Tên Laptop:";
            // 
            // dgvSanPham
            // 
            this.dgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSanPham.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(198)))), ((int)(((byte)(202)))));
            this.dgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSanPham.Location = new System.Drawing.Point(34, 269);
            this.dgvSanPham.Margin = new System.Windows.Forms.Padding(4);
            this.dgvSanPham.Name = "dgvSanPham";
            this.dgvSanPham.RowHeadersWidth = 51;
            this.dgvSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSanPham.Size = new System.Drawing.Size(1049, 318);
            this.dgvSanPham.TabIndex = 63;
            // 
            // Xoa
            // 
            this.Xoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Xoa.Image = global::App_BanLaptop.Properties.Resources.xoa;
            this.Xoa.Location = new System.Drawing.Point(990, 187);
            this.Xoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Xoa.Name = "Xoa";
            this.Xoa.Size = new System.Drawing.Size(43, 40);
            this.Xoa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Xoa.TabIndex = 78;
            this.Xoa.TabStop = false;
            // 
            // Sua
            // 
            this.Sua.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Sua.Image = global::App_BanLaptop.Properties.Resources.sua;
            this.Sua.Location = new System.Drawing.Point(991, 130);
            this.Sua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Sua.Name = "Sua";
            this.Sua.Size = new System.Drawing.Size(42, 38);
            this.Sua.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Sua.TabIndex = 77;
            this.Sua.TabStop = false;
            // 
            // Them
            // 
            this.Them.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Them.Image = global::App_BanLaptop.Properties.Resources.them;
            this.Them.Location = new System.Drawing.Point(991, 69);
            this.Them.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Them.Name = "Them";
            this.Them.Size = new System.Drawing.Size(42, 39);
            this.Them.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Them.TabIndex = 76;
            this.Them.TabStop = false;
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(157, 189);
            this.txtMoTa.Margin = new System.Windows.Forms.Padding(4);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(133, 22);
            this.txtMoTa.TabIndex = 83;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 189);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 20);
            this.label4.TabIndex = 82;
            this.label4.Text = "Mô tả:";
            // 
            // txtNgayCapNhat
            // 
            this.txtNgayCapNhat.Location = new System.Drawing.Point(471, 67);
            this.txtNgayCapNhat.Margin = new System.Windows.Forms.Padding(4);
            this.txtNgayCapNhat.Name = "txtNgayCapNhat";
            this.txtNgayCapNhat.Size = new System.Drawing.Size(133, 22);
            this.txtNgayCapNhat.TabIndex = 85;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(330, 68);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 20);
            this.label7.TabIndex = 84;
            this.label7.Text = "Ngày cập nhật:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(623, 100);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 20);
            this.label8.TabIndex = 86;
            this.label8.Text = "Ảnh bìa:";
            // 
            // txtMaHang
            // 
            this.txtMaHang.Location = new System.Drawing.Point(471, 146);
            this.txtMaHang.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaHang.Name = "txtMaHang";
            this.txtMaHang.Size = new System.Drawing.Size(133, 22);
            this.txtMaHang.TabIndex = 89;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(330, 147);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 20);
            this.label9.TabIndex = 88;
            this.label9.Text = "Mã hàng:";
            // 
            // txtMaNSX
            // 
            this.txtMaNSX.Location = new System.Drawing.Point(471, 187);
            this.txtMaNSX.Margin = new System.Windows.Forms.Padding(4);
            this.txtMaNSX.Name = "txtMaNSX";
            this.txtMaNSX.Size = new System.Drawing.Size(133, 22);
            this.txtMaNSX.TabIndex = 91;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(332, 188);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 20);
            this.label10.TabIndex = 90;
            this.label10.Text = "Mã NSX:";
            // 
            // txtGiaBan
            // 
            this.txtGiaBan.Location = new System.Drawing.Point(157, 146);
            this.txtGiaBan.Margin = new System.Windows.Forms.Padding(4);
            this.txtGiaBan.Name = "txtGiaBan";
            this.txtGiaBan.Size = new System.Drawing.Size(133, 22);
            this.txtGiaBan.TabIndex = 92;
            // 
            // picAnhBia
            // 
            this.picAnhBia.Location = new System.Drawing.Point(740, 101);
            this.picAnhBia.Name = "picAnhBia";
            this.picAnhBia.Size = new System.Drawing.Size(229, 161);
            this.picAnhBia.TabIndex = 93;
            this.picAnhBia.TabStop = false;
            // 
            // QL_SanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 619);
            this.Controls.Add(this.picAnhBia);
            this.Controls.Add(this.txtGiaBan);
            this.Controls.Add(this.txtMaNSX);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtMaHang);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNgayCapNhat);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMoTa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboTimKiem);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.Xoa);
            this.Controls.Add(this.Sua);
            this.Controls.Add(this.Them);
            this.Controls.Add(this.txtMaTinhTrang);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMaMH);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nUDSoLuong);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTenMH);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvSanPham);
            this.Name = "QL_SanPham";
            this.Text = "QL_SanPham";
            ((System.ComponentModel.ISupportInitialize)(this.nUDSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Xoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Sua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Them)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAnhBia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.PictureBox Xoa;
        private System.Windows.Forms.PictureBox Sua;
        private System.Windows.Forms.PictureBox Them;
        private System.Windows.Forms.TextBox txtMaTinhTrang;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaMH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nUDSoLuong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenMH;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvSanPham;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNgayCapNhat;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMaHang;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMaNSX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtGiaBan;
        private System.Windows.Forms.PictureBox picAnhBia;
    }
}