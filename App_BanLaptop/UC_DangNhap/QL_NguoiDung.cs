using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using DAL;
using DTO.ViewModel;

namespace UC_DangNhap
{
    public class QL_NguoiDung
    {
        private KhachHangDAL khachHangDAL;
        public QL_NguoiDung()
        {
            khachHangDAL = new KhachHangDAL();
        }
        public KhachHang GetUserInfo(string username)
        {
            try
            {
                return khachHangDAL.GetKhachHangByUsername(username);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy thông tin người dùng: " + ex.Message);
            }
        }
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
            SqlDataAdapter daUser = new SqlDataAdapter(
                "select MAKH, HOTEN, TAIKHOAN from khachhang where TAIKHOAN='" + pUser +
                "' and MATKHAU ='" + pPass + "' and MAQUYEN = 2", pcnn);
            DataTable dt = new DataTable();
            daUser.Fill(dt);

            if (dt.Rows.Count == 0)
                return LoginResult.Invalid;
            else if (dt.Rows[0][2] == null || dt.Rows[0][2].ToString() == "False")
            {
                return LoginResult.Disabled;
            }

            // Lưu thông tin khách hàng vào SessionManager
            SessionManager.CurrentCustomerId = Convert.ToInt32(dt.Rows[0]["MAKH"]);
            SessionManager.CurrentCustomerName = dt.Rows[0]["HOTEN"].ToString();

            return LoginResult.Success;
        }
    }
}
