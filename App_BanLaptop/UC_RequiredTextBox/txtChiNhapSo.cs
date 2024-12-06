using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;  

namespace UC_RequiredTextBox
{
    public class txtChiNhapSo : TextBox
    {
        private System.Windows.Forms.ErrorProvider errorProvider = new ErrorProvider();
        private bool allowDecimal = false; // Cho phép nhập số thập phân hay không
        private bool allowNegative = false; // Cho phép nhập số âm hay không

        public txtChiNhapSo() {
            this.KeyPress += TxtChiNhapSo_KeyPress;
            this.TextChanged += TxtChiNhapSo_TextChanged;
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }
        // Property để set cho phép nhập số thập phân
        public bool AllowDecimal
        {
            get { return allowDecimal; }
            set { allowDecimal = value; }
        }

        // Property để set cho phép nhập số âm
        public bool AllowNegative
        {
            get { return allowNegative; }
            set { allowNegative = value; }
        }

        private void TxtChiNhapSo_TextChanged(object sender, EventArgs e)
        {
            string text = this.Text;

            // Kiểm tra nếu textbox trống
            if (string.IsNullOrWhiteSpace(text))
            {
                errorProvider.SetError(this, "Vui lòng nhập dữ liệu");
                this.BackColor = Color.LightPink;
                return;
            }

            // Kiểm tra nếu chỉ có dấu trừ
            if (text == "-")
            {
                errorProvider.SetError(this, "Không được nhập số âm");
                this.BackColor = Color.LightPink;
                return;
            }

            // Kiểm tra nếu là số hợp lệ
            if (!decimal.TryParse(text, out decimal value))
            {
                errorProvider.SetError(this, "Vui lòng chỉ nhập số");
                this.BackColor = Color.LightPink;
            }
            else
            {
                // Kiểm tra nếu là số âm
                if (value < 0)
                {
                    errorProvider.SetError(this, "Không được nhập số âm");
                    this.BackColor = Color.LightPink;
                }
                // Kiểm tra nếu là số thập phân
                else if (value % 1 != 0)
                {
                    errorProvider.SetError(this, "Chỉ được nhập số nguyên");
                    this.BackColor = Color.LightPink;
                }
                else
                {
                    errorProvider.SetError(this, "");
                    this.BackColor = SystemColors.Window;
                }
            }
        }

        private void TxtChiNhapSo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Cho phép phím backspace
            if (e.KeyChar == (char)Keys.Back) return;

            // Cho phép dấu âm ở đầu số
            if (e.KeyChar == '-' && allowNegative && this.SelectionStart == 0 && !this.Text.Contains("-"))
            {
                return;
            }

            // Cho phép dấu thập phân
            if (e.KeyChar == '.' && allowDecimal && !this.Text.Contains("."))
            {
                return;
            }

            // Chỉ cho phép nhập số
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                errorProvider.SetError(this, "Vui lòng chỉ nhập số");
            }
            else
            {
                errorProvider.SetError(this, "");
            }
        }

        // Phương thức kiểm tra giá trị có hợp lệ không
        public bool IsValid()
        {
            return decimal.TryParse(this.Text, out _);
        }

        // Phương thức lấy giá trị số
        public decimal? GetValue()
        {
            if (decimal.TryParse(this.Text, out decimal result))
            {
                return result;
            }
            return null;
        }
    }
}
