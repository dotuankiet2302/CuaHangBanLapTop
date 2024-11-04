using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LaptopDAL
    {
        doan_laptopDataContext qlLapTop = new doan_laptopDataContext();
        public LaptopDAL() { }

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
                var existingMonHoc = qlLapTop.laptops.SingleOrDefault(l => l.MALAP == plaptop.MALAP);
                if (existingMonHoc != null)
                {
                    existingMonHoc.TENLAP = plaptop.TENLAP;
                    existingMonHoc.MATINHTRANG = plaptop.MATINHTRANG;
                    existingMonHoc.GIABAN = plaptop.GIABAN;
                    existingMonHoc.MOTA = plaptop.MOTA;
                    existingMonHoc.NGAYCAPNHAT = plaptop.NGAYCAPNHAT;
                    existingMonHoc.ANHBIA = plaptop.ANHBIA;
                    existingMonHoc.SOLUONGTON = plaptop.SOLUONGTON;
                    existingMonHoc.MAHANG = plaptop.MAHANG;
                    existingMonHoc.MANSX = plaptop.MANSX;
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
