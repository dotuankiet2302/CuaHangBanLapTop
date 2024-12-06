using DTO;
using DTO.ViewModel;
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


        public List<donhang> TimKiemDonHang(string keyword)
        {
            return qlLapTop.donhangs
                .Where(d => d.MADH.ToString().Contains(keyword))
                .ToList();
        }
        public List<donhang> TimKiemQuaNgayDat(DateTime keyword)
        {
            //return qlLapTop.donhangs
            //    .Where(d => d.NGAYDAT.ToString().Contains(keyword))
            //    .ToList();
            return qlLapTop.donhangs
                .Where(d => d.NGAYDAT == keyword)
                .ToList();
        }
        public List<DonHang> GetDonHang()
        {
            var query = from dh in qlLapTop.donhangs
                        join kh in qlLapTop.khachhangs on dh.MAKH equals kh.MAKH
                        join ctdh in qlLapTop.chitietdonhangs on dh.MADH equals ctdh.MADH
                        join lap in qlLapTop.laptops on ctdh.MALAP equals lap.MALAP
                        select new DonHang
                        {
                            MaDH = dh.MADH,
                            NgayGiao = (DateTime)dh.NGAYGIAO,  // Thêm chuyển đổi tường minh
                            NgayDat = (DateTime)dh.NGAYDAT,    // Thêm chuyển đổi tường minh
                            DaThanhToan = dh.DATHANHTOAN,
                            TinhTrangGiao = dh.TINHTRANGGIAO,
                            MaKH = (int)dh.MAKH,
                            TenKH = kh.HOTEN,
                            MaLap = lap.MALAP,
                            TenLap = lap.TENLAP,
                            SoLuong = (int)ctdh.SOLUONG,
                            DonGia = (decimal)ctdh.DONGIA
                        };
            return query.ToList();
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
