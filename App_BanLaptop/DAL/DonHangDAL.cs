using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DonHangDAL
    {
        doan_laptopDataContext qlLapTop = new doan_laptopDataContext();
        public DonHangDAL() { }

        public List<donhang> LoadDonHang()
        {
            return qlLapTop.donhangs.Select(d => d).ToList<donhang>();
        }

        public bool ThemDonHang(donhang pDonhang)
        {
            try
            {
                qlLapTop.donhangs.InsertOnSubmit(pDonhang);
                qlLapTop.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SuaDonHang(donhang pDonhang)
        {
            try
            {
                var existingDonHang = qlLapTop.donhangs.SingleOrDefault(d => d.MADH == pDonhang.MADH);
                if (existingDonHang != null)
                {
                    existingDonHang.NGAYGIAO = pDonhang.NGAYGIAO;
                    existingDonHang.NGAYDAT = pDonhang.NGAYDAT;
                    existingDonHang.DATHANHTOAN = pDonhang.DATHANHTOAN;
                    existingDonHang.TINHTRANGGIAO = pDonhang.TINHTRANGGIAO;
                    existingDonHang.MAKH = pDonhang.MAKH;
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

        public bool XoaDonHang(int maDonhang)
        {
            try
            {
                var donHang = qlLapTop.donhangs.SingleOrDefault(d => d.MAKH == maDonhang);
                if (donHang != null)
                {
                    qlLapTop.donhangs.DeleteOnSubmit(donHang);
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
