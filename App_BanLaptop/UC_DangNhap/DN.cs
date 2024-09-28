using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UC_DangNhap
{
    
    public partial class DN: UserControl
    {
        QL_NguoiDung CauHinh = new QL_NguoiDung();
        public event EventHandler GetChange_DN;
        string _CNN;
        bool _TT;

        public string CNN
        {
            get { return _CNN; }
            set { _CNN = value; }
        }

        public bool TT { get => _TT; set => _TT = value; }
        public DN()
        {
            InitializeComponent();
            btnLogin.Click += BtnLogin_Click;
            cbHienMK.CheckedChanged += CbHienMK_CheckedChanged;
        }

        private void CbHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (cbHienMK.Checked)
            {
                txtMK.PasswordChar = '\0'; 
            }
            else
            {
                txtMK.PasswordChar = '*'; 
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            TT = false;
            if (string.IsNullOrWhiteSpace(txtTK.Text.Trim()))
            {
                MessageBox.Show("Không được bỏ trống" + label1.Text.ToLower());
                this.txtTK.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(this.txtMK.Text))
            {
                MessageBox.Show("Không được bỏ trống" + label2.Text.ToLower());
                this.txtMK.Focus();
                return;
            }
            int kq = CauHinh.Check_Config(CNN); //hàm Check_Config() thuộc Class QL_NguoiDung
            if (kq == 0)
            {
                ProcessLogin();// Cấu hình phù hợp xử lý đăng nhập
            }
            if (kq == 1)
            {
                MessageBox.Show("Chuỗi cấu hình không tồn tại");// Xử lý cấu hình
                //ProcessConfig();
            }
            if (kq == 2)
            {
                MessageBox.Show("Chuỗi cấu hình không phù hợp");// Xử lý cấu hình
                //ProcessConfig();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void ProcessLogin()
        {
            LoginResult result;
            result = CauHinh.Check_User(txtTK.Text, txtMK.Text, CNN); //
            //Check_User viết trong Class QL_NguoiDung
            // Wrong username or pass
            if (result == LoginResult.Invalid)
            {
                MessageBox.Show("Sai " + label1.Text + " Hoặc " +
                label2.Text);
                return;
            }
            // Account had been disabled
            else if (result == LoginResult.Disabled)
            {
                MessageBox.Show("Tài khoản bị khóa");
                return;
            }

            TT = true;
            GetChange_DN.Invoke(this, new EventArgs());
        }
    }
    public enum LoginResult
    {
        /// <summary>
        /// Wrong username or password
        /// </summary>
        Invalid,
        /// <summary>
        /// User had been disabled
        /// </summary>
        Disabled,
        /// <summary>
        /// Loging success
        /// </summary>
        Success
    }
}
