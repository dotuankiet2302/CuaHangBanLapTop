namespace UC_DangNhap
{
    partial class DN
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTK = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMK = new System.Windows.Forms.TextBox();
            this.picMK = new System.Windows.Forms.PictureBox();
            this.picTK = new System.Windows.Forms.PictureBox();
            this.cbHienMK = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picMK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTK)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTK
            // 
            this.txtTK.Location = new System.Drawing.Point(57, 55);
            this.txtTK.Multiline = true;
            this.txtTK.Name = "txtTK";
            this.txtTK.Size = new System.Drawing.Size(211, 32);
            this.txtTK.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.Info;
            this.btnLogin.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(89, 182);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(108, 38);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(54, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // txtMK
            // 
            this.txtMK.Location = new System.Drawing.Point(57, 109);
            this.txtMK.Multiline = true;
            this.txtMK.Name = "txtMK";
            this.txtMK.PasswordChar = '*';
            this.txtMK.Size = new System.Drawing.Size(211, 31);
            this.txtMK.TabIndex = 4;
            // 
            // picMK
            // 
            this.picMK.Image = global::UC_DangNhap.Properties.Resources.password;
            this.picMK.Location = new System.Drawing.Point(274, 109);
            this.picMK.Name = "picMK";
            this.picMK.Size = new System.Drawing.Size(43, 39);
            this.picMK.TabIndex = 6;
            this.picMK.TabStop = false;
            // 
            // picTK
            // 
            this.picTK.Image = global::UC_DangNhap.Properties.Resources.user;
            this.picTK.Location = new System.Drawing.Point(275, 55);
            this.picTK.Name = "picTK";
            this.picTK.Size = new System.Drawing.Size(42, 48);
            this.picTK.TabIndex = 5;
            this.picTK.TabStop = false;
            // 
            // cbHienMK
            // 
            this.cbHienMK.AutoSize = true;
            this.cbHienMK.Location = new System.Drawing.Point(72, 156);
            this.cbHienMK.Name = "cbHienMK";
            this.cbHienMK.Size = new System.Drawing.Size(125, 20);
            this.cbHienMK.TabIndex = 7;
            this.cbHienMK.Text = "Show Password";
            this.cbHienMK.UseVisualStyleBackColor = true;
            // 
            // DN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbHienMK);
            this.Controls.Add(this.picMK);
            this.Controls.Add(this.picTK);
            this.Controls.Add(this.txtMK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTK);
            this.Name = "DN";
            this.Size = new System.Drawing.Size(341, 242);
            ((System.ComponentModel.ISupportInitialize)(this.picMK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMK;
        private System.Windows.Forms.PictureBox picTK;
        private System.Windows.Forms.PictureBox picMK;
        private System.Windows.Forms.CheckBox cbHienMK;
    }
}
