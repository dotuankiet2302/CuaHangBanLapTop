using System;

namespace App_BanLaptop
{
    partial class Main
    {
        private System.ComponentModel.IContainer components = null;

        // Khai báo các controls một lần duy nhất
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelTitleBar;   
        private System.Windows.Forms.Panel panelDesktop;
        
        private System.Windows.Forms.Button btnDangXuat;
        private System.Windows.Forms.Button btnTKDoanhThu;
        private System.Windows.Forms.Button btnTinTuc;
        private System.Windows.Forms.Button btnTTKhachHang;
        private System.Windows.Forms.Button btnHoaDon;
        private System.Windows.Forms.Button btnSanPham;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Label TopLabel;
        private System.Windows.Forms.Label lblShopName;
        
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox picDangXuat;
        private System.Windows.Forms.PictureBox picTKDT;
        private System.Windows.Forms.PictureBox picTinTuc;
        private System.Windows.Forms.PictureBox picTTKH;
        private System.Windows.Forms.PictureBox picHoaDon;
        private System.Windows.Forms.PictureBox picSanPham;
        private System.Windows.Forms.PictureBox picNhanVien;

        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnDatHang = new System.Windows.Forms.Button();
            this.picDatHang = new System.Windows.Forms.PictureBox();
            this.btnDangXuat = new System.Windows.Forms.Button();
            this.btnTKDoanhThu = new System.Windows.Forms.Button();
            this.btnTinTuc = new System.Windows.Forms.Button();
            this.btnTTKhachHang = new System.Windows.Forms.Button();
            this.btnHoaDon = new System.Windows.Forms.Button();
            this.btnSanPham = new System.Windows.Forms.Button();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.picDangXuat = new System.Windows.Forms.PictureBox();
            this.picTKDT = new System.Windows.Forms.PictureBox();
            this.picTinTuc = new System.Windows.Forms.PictureBox();
            this.picTTKH = new System.Windows.Forms.PictureBox();
            this.picHoaDon = new System.Windows.Forms.PictureBox();
            this.picSanPham = new System.Windows.Forms.PictureBox();
            this.picNhanVien = new System.Windows.Forms.PictureBox();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.imageStore = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblShopName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.TopLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDatHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDangXuat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTKDT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTinTuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTTKH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNhanVien)).BeginInit();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panelMenu.Controls.Add(this.btnDatHang);
            this.panelMenu.Controls.Add(this.picDatHang);
            this.panelMenu.Controls.Add(this.btnDangXuat);
            this.panelMenu.Controls.Add(this.btnTKDoanhThu);
            this.panelMenu.Controls.Add(this.btnTinTuc);
            this.panelMenu.Controls.Add(this.btnTTKhachHang);
            this.panelMenu.Controls.Add(this.btnHoaDon);
            this.panelMenu.Controls.Add(this.btnSanPham);
            this.panelMenu.Controls.Add(this.btnNhanVien);
            this.panelMenu.Controls.Add(this.picDangXuat);
            this.panelMenu.Controls.Add(this.picTKDT);
            this.panelMenu.Controls.Add(this.picTinTuc);
            this.panelMenu.Controls.Add(this.picTTKH);
            this.panelMenu.Controls.Add(this.picHoaDon);
            this.panelMenu.Controls.Add(this.picSanPham);
            this.panelMenu.Controls.Add(this.picNhanVien);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 673);
            this.panelMenu.TabIndex = 0;
            // 
            // btnDatHang
            // 
            this.btnDatHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatHang.ForeColor = System.Drawing.Color.Snow;
            this.btnDatHang.Location = new System.Drawing.Point(70, 201);
            this.btnDatHang.Name = "btnDatHang";
            this.btnDatHang.Size = new System.Drawing.Size(120, 40);
            this.btnDatHang.TabIndex = 16;
            this.btnDatHang.Text = "Đặt Hàng";
            // 
            // picDatHang
            // 
            this.picDatHang.ErrorImage = null;
            this.picDatHang.Image = global::App_BanLaptop.Properties.Resources.datHang;
            this.picDatHang.Location = new System.Drawing.Point(12, 196);
            this.picDatHang.Name = "picDatHang";
            this.picDatHang.Size = new System.Drawing.Size(50, 50);
            this.picDatHang.TabIndex = 17;
            this.picDatHang.TabStop = false;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangXuat.ForeColor = System.Drawing.Color.Snow;
            this.btnDangXuat.Location = new System.Drawing.Point(70, 621);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(120, 40);
            this.btnDangXuat.TabIndex = 0;
            this.btnDangXuat.Text = "Đăng Xuất";
            // 
            // btnTKDoanhThu
            // 
            this.btnTKDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTKDoanhThu.ForeColor = System.Drawing.Color.Snow;
            this.btnTKDoanhThu.Location = new System.Drawing.Point(70, 501);
            this.btnTKDoanhThu.Name = "btnTKDoanhThu";
            this.btnTKDoanhThu.Size = new System.Drawing.Size(120, 40);
            this.btnTKDoanhThu.TabIndex = 1;
            this.btnTKDoanhThu.Text = "Thống Kê";
            // 
            // btnTinTuc
            // 
            this.btnTinTuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTinTuc.ForeColor = System.Drawing.Color.Snow;
            this.btnTinTuc.Location = new System.Drawing.Point(70, 559);
            this.btnTinTuc.Name = "btnTinTuc";
            this.btnTinTuc.Size = new System.Drawing.Size(120, 40);
            this.btnTinTuc.TabIndex = 2;
            this.btnTinTuc.Text = "Tin Tức";
            // 
            // btnTTKhachHang
            // 
            this.btnTTKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTTKhachHang.ForeColor = System.Drawing.Color.Snow;
            this.btnTTKhachHang.Location = new System.Drawing.Point(70, 259);
            this.btnTTKhachHang.Name = "btnTTKhachHang";
            this.btnTTKhachHang.Size = new System.Drawing.Size(120, 40);
            this.btnTTKhachHang.TabIndex = 3;
            this.btnTTKhachHang.Text = "Khách Hàng";
            // 
            // btnHoaDon
            // 
            this.btnHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHoaDon.ForeColor = System.Drawing.Color.Snow;
            this.btnHoaDon.Location = new System.Drawing.Point(70, 441);
            this.btnHoaDon.Name = "btnHoaDon";
            this.btnHoaDon.Size = new System.Drawing.Size(120, 40);
            this.btnHoaDon.TabIndex = 4;
            this.btnHoaDon.Text = "Đơn Hàng";
            // 
            // btnSanPham
            // 
            this.btnSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSanPham.ForeColor = System.Drawing.Color.Snow;
            this.btnSanPham.Location = new System.Drawing.Point(70, 139);
            this.btnSanPham.Name = "btnSanPham";
            this.btnSanPham.Size = new System.Drawing.Size(120, 40);
            this.btnSanPham.TabIndex = 5;
            this.btnSanPham.Text = "Laptop";
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhanVien.ForeColor = System.Drawing.Color.Snow;
            this.btnNhanVien.Location = new System.Drawing.Point(70, 318);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(120, 40);
            this.btnNhanVien.TabIndex = 6;
            this.btnNhanVien.Text = "Nhân Viên";
            // 
            // picDangXuat
            // 
            this.picDangXuat.ErrorImage = null;
            this.picDangXuat.Image = global::App_BanLaptop.Properties.Resources.dangxuat;
            this.picDangXuat.Location = new System.Drawing.Point(12, 616);
            this.picDangXuat.Name = "picDangXuat";
            this.picDangXuat.Size = new System.Drawing.Size(50, 50);
            this.picDangXuat.TabIndex = 7;
            this.picDangXuat.TabStop = false;
            // 
            // picTKDT
            // 
            this.picTKDT.Image = global::App_BanLaptop.Properties.Resources.thongkedoanhthu;
            this.picTKDT.Location = new System.Drawing.Point(12, 496);
            this.picTKDT.Name = "picTKDT";
            this.picTKDT.Size = new System.Drawing.Size(50, 50);
            this.picTKDT.TabIndex = 8;
            this.picTKDT.TabStop = false;
            // 
            // picTinTuc
            // 
            this.picTinTuc.Image = global::App_BanLaptop.Properties.Resources.czp156755920311;
            this.picTinTuc.Location = new System.Drawing.Point(12, 554);
            this.picTinTuc.Name = "picTinTuc";
            this.picTinTuc.Size = new System.Drawing.Size(50, 50);
            this.picTinTuc.TabIndex = 9;
            this.picTinTuc.TabStop = false;
            // 
            // picTTKH
            // 
            this.picTTKH.Image = global::App_BanLaptop.Properties.Resources.thongtinban1;
            this.picTTKH.Location = new System.Drawing.Point(12, 254);
            this.picTTKH.Name = "picTTKH";
            this.picTTKH.Size = new System.Drawing.Size(50, 50);
            this.picTTKH.TabIndex = 10;
            this.picTTKH.TabStop = false;
            // 
            // picHoaDon
            // 
            this.picHoaDon.Image = global::App_BanLaptop.Properties.Resources.hoadon1;
            this.picHoaDon.Location = new System.Drawing.Point(12, 436);
            this.picHoaDon.Name = "picHoaDon";
            this.picHoaDon.Size = new System.Drawing.Size(50, 50);
            this.picHoaDon.TabIndex = 11;
            this.picHoaDon.TabStop = false;
            // 
            // picSanPham
            // 
            this.picSanPham.Image = global::App_BanLaptop.Properties.Resources.shopping1;
            this.picSanPham.Location = new System.Drawing.Point(12, 134);
            this.picSanPham.Name = "picSanPham";
            this.picSanPham.Size = new System.Drawing.Size(50, 50);
            this.picSanPham.TabIndex = 12;
            this.picSanPham.TabStop = false;
            // 
            // picNhanVien
            // 
            this.picNhanVien.Image = global::App_BanLaptop.Properties.Resources.nhanvien2;
            this.picNhanVien.Location = new System.Drawing.Point(12, 313);
            this.picNhanVien.Name = "picNhanVien";
            this.picNhanVien.Size = new System.Drawing.Size(50, 50);
            this.picNhanVien.TabIndex = 13;
            this.picNhanVien.TabStop = false;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panelLogo.Controls.Add(this.imageStore);
            this.panelLogo.Controls.Add(this.panel2);
            this.panelLogo.Controls.Add(this.lblShopName);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 120);
            this.panelLogo.TabIndex = 15;
            // 
            // imageStore
            // 
            this.imageStore.Image = global::App_BanLaptop.Properties.Resources.laptop;
            this.imageStore.Location = new System.Drawing.Point(70, 12);
            this.imageStore.Name = "imageStore";
            this.imageStore.Size = new System.Drawing.Size(85, 85);
            this.imageStore.TabIndex = 20;
            this.imageStore.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(390, 100);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1260, 585);
            this.panel2.TabIndex = 9;
            // 
            // lblShopName
            // 
            this.lblShopName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblShopName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblShopName.ForeColor = System.Drawing.Color.White;
            this.lblShopName.Location = new System.Drawing.Point(0, 90);
            this.lblShopName.Name = "lblShopName";
            this.lblShopName.Size = new System.Drawing.Size(220, 30);
            this.lblShopName.TabIndex = 0;
            this.lblShopName.Text = "LAPTOP STORE";
            this.lblShopName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(220, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 673);
            this.panel1.TabIndex = 1;
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(220, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(780, 40);
            this.panelTitleBar.TabIndex = 2;
            // 
            // panelDesktop
            // 
            this.panelDesktop.Location = new System.Drawing.Point(0, 0);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(200, 100);
            this.panelDesktop.TabIndex = 0;
            // 
            // TopLabel
            // 
            this.TopLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.TopLabel.Location = new System.Drawing.Point(0, 0);
            this.TopLabel.Name = "TopLabel";
            this.TopLabel.Size = new System.Drawing.Size(100, 23);
            this.TopLabel.TabIndex = 0;
            this.TopLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 673);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelMenu);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDatHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDangXuat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTKDT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTinTuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTTKH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNhanVien)).EndInit();
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDatHang;
        private System.Windows.Forms.PictureBox picDatHang;
        private System.Windows.Forms.PictureBox imageStore;
    }
}

