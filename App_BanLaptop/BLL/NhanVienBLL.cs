using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class NhanVienBLL
    {
        NhanVienDAL dalNhanVien = new NhanVienDAL();
        public NhanVienBLL() { }

        public List<khachhang> GetNhanVien()
        {
            return dalNhanVien.LoadNhanVien();
        }

        public bool ThemNhanVien(khachhang pNhanVien)
        {
            //if (KiemTraMaMonHoc(pMonHoc.MaMonHoc))
            //{
            //    return false; // Mã môn học đã tồn tại
            //}
            return dalNhanVien.ThemNhanVien(pNhanVien);
        }

        public bool SuaNhanVien(khachhang pNhanVien)
        {
            return dalNhanVien.SuaNhanVien(pNhanVien);
        }

        public bool XoaNhanVien(int maNhanVien)
        {
            try
            {
                return dalNhanVien.XoaNhanVien(maNhanVien);
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
