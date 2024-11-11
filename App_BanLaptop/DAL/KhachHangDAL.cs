using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class KhachHangDAL
    {
        doan_laptopDataContext qlLapTop = new doan_laptopDataContext();

        public KhachHangDAL()
        {

        }
        public List<khachhang> LoadKhachHang()
        {
            return qlLapTop.khachhangs.Select(kh => kh).ToList<khachhang>();
        }

        public bool ThemKhachHang(khachhang pKhachHang)
        {
            try
            {
                qlLapTop.khachhangs.InsertOnSubmit(pKhachHang);
                qlLapTop.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SuaKhachHang(khachhang pKhachHang)
        {
            try
            {
                var existingKhachHang = qlLapTop.khachhangs.SingleOrDefault(n => n.MAKH == pKhachHang.MAKH);
                if (existingKhachHang != null)
                {
                    existingKhachHang.HOTEN = pKhachHang.HOTEN;
                    existingKhachHang.NGAYSINH = pKhachHang.NGAYSINH;
                    existingKhachHang.GIOITINH = pKhachHang.GIOITINH;
                    existingKhachHang.DIENTHOAI = pKhachHang.DIENTHOAI;
                    existingKhachHang.TAIKHOAN = pKhachHang.TAIKHOAN;
                    existingKhachHang.MATKHAU = pKhachHang.MATKHAU;
                    existingKhachHang.EMAIL = pKhachHang.EMAIL;
                    existingKhachHang.DIACHI = pKhachHang.DIACHI;
                    existingKhachHang.MAQUYEN = pKhachHang.MAQUYEN;
                    existingKhachHang.MATINH = pKhachHang.MATINH;
                    qlLapTop.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool XoaKhachHang(int maKhachHang)
        {
            try
            {
                var khachHang = qlLapTop.khachhangs.SingleOrDefault(n => n.MAKH == maKhachHang);
                if (khachHang != null)
                {
                    qlLapTop.khachhangs.DeleteOnSubmit(khachHang);
                    qlLapTop.SubmitChanges();
                    return true; // Xóa thành công
                }
                return false; // Mã môn học không tồn tại
            }
            catch
            {
                return false; // Xảy ra lỗi trong quá trình xóa
            }
        }
    }
}
