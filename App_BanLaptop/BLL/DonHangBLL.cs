using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class DonHangBLL
    {
        DonHangDAL dalDonHang = new DonHangDAL();
        public DonHangBLL() { }

        public List<donhang> GetDonHang()
        {
            return dalDonHang.LoadDonHang();
        }

        public bool ThemDonHang(donhang pDonHang)
        {
            //if (KiemTraMaMonHoc(pMonHoc.MaMonHoc))
            //{
            //    return false; // Mã môn học đã tồn tại
            //}
            return dalDonHang.ThemDonHang(pDonHang);
        }

        public bool SuaDonHang(donhang pDonHang)
        {
            return dalDonHang.SuaDonHang(pDonHang);
        }

        public bool XoaDonHang(int maDonHang)
        {
            try
            {
                return dalDonHang.XoaDonHang(maDonHang);
            }
            catch (Exception ex)
            {
                // Ghi log lỗi hoặc xử lý theo cách khác nếu cần
                Console.WriteLine("Lỗi xóa Đơn hàng: " + ex.Message);
                return false; // Trả về false nếu có lỗi
            }
        }
    }
}
