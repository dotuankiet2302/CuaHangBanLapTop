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
        doan_laptopDataContext qlLapTop;

        public NhanVienDAL()
        {
            qlLapTop = new doan_laptopDataContext();
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
                var existingNhanVien = qlLapTop.khachhangs.SingleOrDefault(n => n.MAKH == pNhanVien.MAKH);
                if (existingNhanVien != null)
                {
                    existingNhanVien.HOTEN = pNhanVien.HOTEN;
                    existingNhanVien.NGAYSINH = pNhanVien.NGAYSINH;
                    existingNhanVien.GIOITINH = pNhanVien.GIOITINH;
                    existingNhanVien.DIENTHOAI = pNhanVien.DIENTHOAI;
                    existingNhanVien.TAIKHOAN = pNhanVien.TAIKHOAN;
                    existingNhanVien.MATKHAU = pNhanVien.MATKHAU;
                    existingNhanVien.EMAIL = pNhanVien.EMAIL;
                    existingNhanVien.DIACHI = pNhanVien.DIACHI;
                    existingNhanVien.MAQUYEN = pNhanVien.MAQUYEN;
                    existingNhanVien.MATINH = pNhanVien.MATINH;
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
