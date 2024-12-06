using DAL;
using DTO;
using DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class DatHangBLL
    {
        private DatHangDAL datHangDAL;

        public DatHangBLL()
        {
            datHangDAL = new DatHangDAL();
        }

        public List<Laptop> GetPurchaseHistory(int customerId)
        {
            try
            {
                // Lấy danh sách các hóa đơn của khách hàng
                var orders = datHangDAL.GetOrdersByCustomerId(customerId);

                // Lấy danh sách laptop từ chi tiết hóa đơn
                var laptops = new List<Laptop>();
                foreach (var order in orders)
                {
                    var orderDetails = datHangDAL.GetOrderDetails(order.MaDH);
                    foreach (var detail in orderDetails)
                    {
                        var laptop = datHangDAL.GetLaptopById(detail.MaSP);
                        if (laptop != null && !laptops.Any(l => l.MaLap == laptop.MaLap))
                        {
                            laptops.Add(laptop);
                        }
                    }
                }
                return laptops;
            }
            catch (Exception)
            {
                return new List<Laptop>();
            }
        }

        public List<Laptop> GetAllSanPham()
        {
            var danhSachSanPhamDTO = datHangDAL.GetAllSanPham();
            //return dalLaptop.LoadLaptop();
            return danhSachSanPhamDTO.Select(sp => new Laptop
            {
                MaLap = sp.MALAP,
                TenLap = sp.TENLAP,
                MaTinhTrang = (int)sp.MATINHTRANG,
                GiaBan = (decimal)sp.GIABAN,
                MoTa = sp.MOTA,
                NgayCapNhat = (DateTime)sp.NGAYCAPNHAT,
                AnhBia = sp.ANHBIA,
                SoLuongTon = (int)sp.SOLUONGTON,
                MaHang = (int)sp.MAHANG,
                MaNSX = (int)sp.MANSX
            }).ToList();
        }

        public bool ThemDonHang(int maKH, int maSP, int soLuong, decimal gia)
        {
            try
            {
                var donHangDTO = new DonHangDTO
                {
                    MaHD = datHangDAL.GetNewMaHD(),
                    MaKH = maKH,
                    NgayDat = DateTime.Now,
                    ChiTietDonHang = new List<ChiTietDonHangDTO>
            {
                new ChiTietDonHangDTO
                {
                    MaHD = datHangDAL.GetNewMaHD(),
                    MaSP = maSP,
                    SoLuong = soLuong,
                    Gia = gia
                }
            }
                };

                return datHangDAL.LuuDonHang(donHangDTO);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm đơn hàng: " + ex.Message);
            }
        }
    }
}
