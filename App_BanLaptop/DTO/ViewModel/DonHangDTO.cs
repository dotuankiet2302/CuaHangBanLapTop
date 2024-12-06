using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DonHangDTO
    {
        public int MaHD { get; set; }
        public int MaKH { get; set; }
        public DateTime NgayDat { get; set; }
        public List<ChiTietDonHangDTO> ChiTietDonHang { get; set; }

        public DonHangDTO()
        {
            ChiTietDonHang = new List<ChiTietDonHangDTO>();
        }
    }
}
