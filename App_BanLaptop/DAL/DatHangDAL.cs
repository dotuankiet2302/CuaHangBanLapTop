using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DTO;  // Cho các class model
using System.Configuration;
using DTO.ViewModel;

namespace DAL
{
    public class DatHangDAL
    {
        private readonly string connectionString;
        private readonly doan_laptopDataContext qlLapTop;

        public DatHangDAL()
        {
            try
            {
                // Đọc connection string từ file App.config
                connectionString = System.Configuration.ConfigurationManager
                    .ConnectionStrings["CNN"]
                    .ConnectionString;

                qlLapTop = new doan_laptopDataContext();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kết nối database: " + ex.Message);
            }
        }

        public List<laptop> GetAllSanPham()
        {
            return qlLapTop.laptops.Select(l => l).ToList<laptop>();
        }

        public bool LuuDonHang(DonHangDTO donHang)
        {
            using (var scope = new TransactionScope())
            {
                try
                {
                    // Thêm đơn hàng
                    var dh = new donhang
                    {
                        MADH = donHang.MaHD,
                        MAKH = donHang.MaKH,
                        NGAYDAT = donHang.NgayDat,
                        DATHANHTOAN = "Chưa thanh toán",
                        TINHTRANGGIAO = "Chờ xử lý",
                        NGAYGIAO = DateTime.Now.AddDays(3)
                    };
                    qlLapTop.donhangs.InsertOnSubmit(dh);

                    // Thêm chi tiết đơn hàng
                    foreach (var item in donHang.ChiTietDonHang)
                    {
                        var ctdh = new chitietdonhang
                        {
                            MADH = donHang.MaHD,
                            MALAP = item.MaSP,
                            SOLUONG = item.SoLuong,
                            DONGIA = (double)item.Gia
                        };
                        qlLapTop.chitietdonhangs.InsertOnSubmit(ctdh);

                        // Cập nhật số lượng tồn
                        var laptop = qlLapTop.laptops.FirstOrDefault(l => l.MALAP == item.MaSP);
                        if (laptop != null)
                        {
                            laptop.SOLUONGTON -= item.SoLuong;
                        }
                    }

                    qlLapTop.SubmitChanges();
                    scope.Complete();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception("Lỗi khi lưu đơn hàng: " + ex.Message);
                }
            }
        }

        public int GetNewMaHD()
        {
            return (qlLapTop.donhangs.Max(h => (int?)h.MADH) ?? 0) + 1;
        }


        public List<DonHang> GetOrdersByCustomerId(int customerId)
        {
            try
            {
                return qlLapTop.donhangs
                    .Where(h => h.MAKH == customerId)
                    .Select(h => new DonHang
                    {
                        MaDH = h.MADH,
                        MaKH =(int)h.MAKH,
                        NgayDat = (DateTime)h.NGAYDAT
                        // Thêm các trường khác nếu cần
                    })
                    .ToList();
            }
            catch
            {
                return new List<DonHang>();
            }
        }

        public List<ChiTietDonHangDTO> GetOrderDetails(int orderId)
        {
            try
            {
                return qlLapTop.chitietdonhangs
                    .Where(ct => ct.MADH == orderId)
                    .Select(ct => new ChiTietDonHangDTO
                    {
                        MaHD = ct.MADH,
                        MaSP = ct.MALAP,
                        SoLuong = (int)ct.SOLUONG
                        // Thêm các trường khác nếu cần
                    })
                    .ToList();
            }
            catch
            {
                return new List<ChiTietDonHangDTO>();
            }
        }

        public Laptop GetLaptopById(int laptopId)
        {
            try
            {
                var result = qlLapTop.laptops
                    .Where(l => l.MALAP == laptopId)
                    .Select(l => new Laptop
                    {
                        MaLap = l.MALAP,
                        TenLap = l.TENLAP,
                        GiaBan = (decimal)l.GIABAN
                        // Thêm các trường khác nếu cần
                    })
                    .FirstOrDefault();

                return result;
            }
            catch
            {
                return null;
            }
        }
    }
}
