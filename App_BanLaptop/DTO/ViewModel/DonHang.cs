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
        private string tenKH;
        private int maLap;
        private string tenLap;
        private int soLuong;
        private decimal donGia;

        public int MaDH { get => maDH; set => maDH = value; }
        public DateTime NgayGiao { get => ngayGiao; set => ngayGiao = value; }
        public DateTime NgayDat { get => ngayDat; set => ngayDat = value; }
        public string DaThanhToan { get => daThanhToan; set => daThanhToan = value; }
        public string TinhTrangGiao { get => tinhTrangGiao; set => tinhTrangGiao = value; }
        public int MaKH { get => maKH; set => maKH = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public int MaLap { get => maLap; set => maLap = value; }
        public string TenLap { get => tenLap; set => tenLap = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public decimal DonGia { get => donGia; set => donGia = value; }
        public decimal ThanhTien => SoLuong * DonGia;
    }
}
