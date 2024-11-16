using DTO;
using DTO.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LaptopDAL
    {
        doan_laptopDataContext qlLapTop = new doan_laptopDataContext();
        public LaptopDAL() { }

        public List<laptop> SearchProducts(string keyword)
        {
            return qlLapTop.laptops
                .Where(p => p.TENLAP.Contains(keyword))
                .ToList();
        }
        public List<laptop> SearchProductsByPrice(decimal maxPrice)
        {
            return qlLapTop.laptops
                .Where(p => p.GIABAN <= maxPrice)
                .ToList();
        }
        public List<laptop> LoadLaptop()
        {
            return qlLapTop.laptops.Select(l => l).ToList<laptop>();
        }

        public bool ThemLaptop(laptop plaptop)
        {
            try
            {
                qlLapTop.laptops.InsertOnSubmit(plaptop);
                qlLapTop.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool SuaLaptop(laptop plaptop)
        {
            try
            {
                var existingLaptop = qlLapTop.laptops.SingleOrDefault(l => l.MALAP == plaptop.MALAP);
                if (existingLaptop != null)
                {
                    existingLaptop.TENLAP = plaptop.TENLAP;
                    existingLaptop.MATINHTRANG = plaptop.MATINHTRANG;
                    existingLaptop.GIABAN = plaptop.GIABAN;
                    existingLaptop.MOTA = plaptop.MOTA;
                    existingLaptop.NGAYCAPNHAT = plaptop.NGAYCAPNHAT;
                    existingLaptop.ANHBIA = plaptop.ANHBIA;
                    existingLaptop.SOLUONGTON = plaptop.SOLUONGTON;
                    existingLaptop.MAHANG = plaptop.MAHANG;
                    existingLaptop.MANSX = plaptop.MANSX;
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

        public bool XoaLaptop(int maLaptop)
        {
            try
            {
                var lapTop = qlLapTop.laptops.SingleOrDefault(l => l.MALAP == maLaptop);
                if (lapTop != null)
                {
                    qlLapTop.laptops.DeleteOnSubmit(lapTop);
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
