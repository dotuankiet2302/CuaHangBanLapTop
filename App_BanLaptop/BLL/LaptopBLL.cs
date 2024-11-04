using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class LaptopBLL
    {
        LaptopDAL dalLaptop = new LaptopDAL();
        public LaptopBLL() { }

        public List<laptop> GetLaptop()
        {
            return dalLaptop.LoadLaptop();
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
