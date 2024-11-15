using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.ViewModel
{
    public class Laptop
    {
        private int maLap;
        private string tenLap;
        private int maTinhTrang;
        private decimal giaBan;
        private string moTa;
        private DateTime ngayCapNhat;
        private string anhBia;
        private int soLuongTon;
        private int maHang;
        private int maNSX;

        public int MaLap { get => maLap; set => maLap = value; }
        public string TenLap { get => tenLap; set => tenLap = value; }
        public int MaTinhTrang { get => maTinhTrang; set => maTinhTrang = value; }
        public decimal GiaBan { get => giaBan; set => giaBan = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public DateTime NgayCapNhat { get => ngayCapNhat; set => ngayCapNhat = value; }
        public string AnhBia { get => anhBia; set => anhBia = value; }
        public int SoLuongTon { get => soLuongTon; set => soLuongTon = value; }
        public int MaHang { get => maHang; set => maHang = value; }
        public int MaNSX { get => maNSX; set => maNSX = value; }
    }
}
