using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UC_DangNhap
{
    public class QL_NguoiDung
    {
        public QL_NguoiDung() { }
        public int Check_Config(string pcnn)
        {
            if (pcnn == string.Empty)
                return 1;// Chuỗi cấu hình không tồn tạiSqlConnection _Sqlconn = new
            SqlConnection _Sqlconn = new SqlConnection(pcnn);
            try
            {
                if (_Sqlconn.State == System.Data.ConnectionState.Closed)
                    _Sqlconn.Open();
                return 0;// Kết nối thành công chuỗi cấu hình hợp lệ
            }
            catch
            {
                return 2;// Chuỗi cấu hình không phù hợp.
            }
        }

        public LoginResult Check_User(string pUser, string pPass, string pcnn)
        {
            SqlDataAdapter daUser = new SqlDataAdapter("select * from khachhang where TAIKHOAN='" + pUser + "' and MATKHAU ='" + pPass + "'", pcnn);
            DataTable dt = new DataTable();
            daUser.Fill(dt);
            if (dt.Rows.Count == 0)
                return LoginResult.Invalid;// User không tồn tại
            else if (dt.Rows[0][2] == null || dt.Rows[0][2].ToString() == "False")
            {
                return LoginResult.Disabled;// Không hoạt động
            }
            return LoginResult.Success;// Đăng nhập thành công
        }
    }
}
