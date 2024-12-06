using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UC_RequiredTextBox
{
    public class txtKhongDeTrong : TextBox
    {
        private ErrorProvider errorProvider = new ErrorProvider();

        public txtKhongDeTrong()
        {
            this.TextChanged += TxtKhongDeTrong_TextChanged;
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        private void TxtKhongDeTrong_TextChanged(object sender, EventArgs e)
        {
            string text = this.Text;

            // Kiểm tra nếu textbox trống
            if (string.IsNullOrWhiteSpace(text))
            {
                errorProvider.SetError(this, "Vui lòng nhập dữ liệu");
                this.BackColor = Color.LightPink;
            }
            else
            {
                errorProvider.SetError(this, "");
                this.BackColor = SystemColors.Window;
            }
        }

        // Phương thức kiểm tra giá trị có hợp lệ không
        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(this.Text);
        }
    }
}
