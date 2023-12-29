using System;

namespace MyWebApiBasic.Data
{
    public class DonHangChiTiet
    {
        public Guid MaHh { get; set; }
        public Guid MaDonHang { get; set; }
        public int SoLuong { get; set; }
        public double DonGia { get; set; }
        public byte GiamGia { get; set; }

        public DonHang DonHang { get; set; }
        public HangHoa HangHoa { get; set; }

    }
}
