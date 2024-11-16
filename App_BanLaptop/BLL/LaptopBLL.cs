using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using DTO.ViewModel;

namespace BLL
{
    public class LaptopBLL
    {
        LaptopDAL dalLaptop = new LaptopDAL();
        Laptop dtoLaptop = new Laptop();
        public LaptopBLL() { }

        public List<Laptop> SearchProductsByPrice(decimal maxPrice)
        {
            var products = dalLaptop.SearchProductsByPrice(maxPrice); // Gọi hàm tìm kiếm trong DAL
            var productViewModels = new List<Laptop>();

            foreach (var product in products)
            {
                productViewModels.Add(new Laptop
                {
                    MaLap = product.MALAP,
                    TenLap = product.TENLAP,
                    MaTinhTrang = (int)product.MATINHTRANG,
                    GiaBan = (decimal)product.GIABAN,
                    MoTa = product.MOTA,
                    NgayCapNhat = (DateTime)product.NGAYCAPNHAT,
                    AnhBia = product.ANHBIA,
                    SoLuongTon = (int)product.SOLUONGTON,
                    MaHang = (int)product.MAHANG,
                    MaNSX = (int)product.MANSX
                });
            }

            return productViewModels;
        }
        public List<Laptop> SearchProducts(string keyword)
        {
            var products = dalLaptop.SearchProducts(keyword);
            var productViewModels = new List<Laptop>();

            foreach (var product in products)
            {
                productViewModels.Add(new Laptop
                {
                    MaLap = product.MALAP,
                    TenLap = product.TENLAP,
                    MaTinhTrang = (int)product.MATINHTRANG,
                    GiaBan = (decimal)product.GIABAN,
                    MoTa = product.MOTA,
                    NgayCapNhat = (DateTime)product.NGAYCAPNHAT,
                    AnhBia = product.ANHBIA,
                    SoLuongTon = (int)product.SOLUONGTON,
                    MaHang = (int)product.MAHANG,
                    MaNSX = (int)product.MANSX
                });
            }

            return productViewModels;
        }
        public List<Laptop> GetLaptop()
        {
            var danhSachSanPhamDTO = dalLaptop.LoadLaptop();
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

        public bool ThemLaptop(laptop pLaptop)
        {
            //if (KiemTraMaMonHoc(pMonHoc.MaMonHoc))
            //{
            //    return false; // Mã môn học đã tồn tại
            //}
            return dalLaptop.ThemLaptop(pLaptop);
        }

        public bool SuaLaptop(laptop pLaptop)
        {
            return dalLaptop.SuaLaptop(pLaptop);
        }

        public bool XoaLaptop(int maLaptop)
        {
            try
            {
                return dalLaptop.XoaLaptop(maLaptop);
            }
            catch (Exception ex)
            {
                // Ghi log lỗi hoặc xử lý theo cách khác nếu cần
                Console.WriteLine("Lỗi xóa Laptop: " + ex.Message);
                return false; // Trả về false nếu có lỗi
            }
        }
    }
}
