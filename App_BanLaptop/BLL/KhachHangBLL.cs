using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class KhachHangBLL
    {
        KhachHangDAL dalKhachHang = new KhachHangDAL();
        public KhachHangBLL() { }

        public List<khachhang> GetKhachHang()
        {
            return dalKhachHang.LoadKhachHang();
        }

        public bool ThemKhachHang(khachhang pKhachHang)
        {
            //if (KiemTraMaMonHoc(pMonHoc.MaMonHoc))
            //{
            //    return false; // Mã môn học đã tồn tại
            //}
            return dalKhachHang.ThemKhachHang(pKhachHang);
        }

        public bool SuaKhachHang(khachhang pKhachHang)
        {
            return dalKhachHang.SuaKhachHang(pKhachHang);
        }

        public bool XoaKhachHang(int maKhachHang)
        {
            try
            {
                return dalKhachHang.XoaKhachHang(maKhachHang);
            }
            catch (Exception ex)
            {
                // Ghi log lỗi hoặc xử lý theo cách khác nếu cần
                Console.WriteLine("Lỗi xóa nhân vien: " + ex.Message);
                return false; // Trả về false nếu có lỗi
            }
        }
    }
}
