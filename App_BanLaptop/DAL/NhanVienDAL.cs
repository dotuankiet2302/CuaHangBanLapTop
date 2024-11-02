using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class NhanVienDAL
    {
        doan_laptopDataContext qlLapTop = new doan_laptopDataContext();

        public NhanVienDAL()
        {

        }
        public List<khachhang> LoadNhanVien()
        {
            return qlLapTop.khachhangs.Select(kh => kh).ToList<khachhang>();
        }

        public bool ThemNhanVien(khachhang pNhanVien)
        {
            try
            {
                qlLapTop.khachhangs.InsertOnSubmit(pNhanVien);
                qlLapTop.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SuaNhanVien(khachhang pNhanVien)
        {
            try
            {
                var existingMonHoc = qlLapTop.khachhangs.SingleOrDefault(n => n.MAKH == pNhanVien.MAKH);
                if (existingMonHoc != null)
                {
                    existingMonHoc.HOTEN = pNhanVien.HOTEN;
                    existingMonHoc.NGAYSINH = pNhanVien.NGAYSINH;
                    existingMonHoc.GIOITINH = pNhanVien.GIOITINH;
                    existingMonHoc.DIENTHOAI = pNhanVien.DIENTHOAI;
                    existingMonHoc.TAIKHOAN = pNhanVien.TAIKHOAN;
                    existingMonHoc.MATKHAU = pNhanVien.MATKHAU;
                    existingMonHoc.EMAIL = pNhanVien.EMAIL;
                    existingMonHoc.DIACHI = pNhanVien.DIACHI;
                    existingMonHoc.MAQUYEN = pNhanVien.MAQUYEN;
                    existingMonHoc.MATINH = pNhanVien.MATINH;
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

        public bool XoaNhanVien(int maNhanVien)
        {
            try
            {
                var nhanVien = qlLapTop.khachhangs.SingleOrDefault(n => n.MAKH == maNhanVien);
                if (nhanVien != null)
                {
                    qlLapTop.khachhangs.DeleteOnSubmit(nhanVien);
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
