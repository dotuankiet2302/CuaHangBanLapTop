using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App_BanLaptop.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.Load += Login_Load;
            dn1.GetChange_DN += Dn1_GetChange_DN;
            btnExit.Click += BtnExit_Click;
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có muốn thoát hay không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Dn1_GetChange_DN(object sender, EventArgs e)
        {
            if (dn1.TT == true)
            {
                MessageBox.Show("Đăng nhập thành công");

                if (Program.mainForm == null || Program.mainForm.IsDisposed)
                {
                    Program.mainForm = new Main();
                }
                this.Visible = false;
                Program.mainForm.Show();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            dn1.CNN = App_BanLaptop.Properties.Settings.Default.CNN;
        }
    }
}
