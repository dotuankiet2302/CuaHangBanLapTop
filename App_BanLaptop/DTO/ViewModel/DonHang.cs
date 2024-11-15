using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ViewModel
{
    public class DonHang
    {
        private int maDH;
        private DateTime ngayGiao;
        private DateTime ngayDat;
        private string daThanhToan;
        private string tinhTrangGiao;
        private int maKH;

        public int MaDH { get => maDH; set => maDH = value; }
        public DateTime NgayGiao { get => ngayGiao; set => ngayGiao = value; }
        public DateTime NgayDat { get => ngayDat; set => ngayDat = value; }
        public string DaThanhToan { get => daThanhToan; set => daThanhToan = value; }
        public string TinhTrangGiao { get => tinhTrangGiao; set => tinhTrangGiao = value; }
        public int MaKH { get => maKH; set => maKH = value; }
    }
}
