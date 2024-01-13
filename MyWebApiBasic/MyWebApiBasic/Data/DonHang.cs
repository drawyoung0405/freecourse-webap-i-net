using System;
using System.Collections.Generic;

namespace MyWebApiBasic.Data
{
    public enum TinhTrangDonHang
    {
        New = 0, MadePayment = 1, Complete = 2, Cancel = -1
    }
    public class DonHang
    {
        public Guid MaDonHang { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime NgayGiao { get; set;  }
        public TinhTrangDonHang TinhTrangDonHang { get; set; }
        public string NguoiNhanHang { get; set; }
        public string DiaChiGiao { get; set; }
        public string SoDienThoai { get; set; }

        public ICollection<DonHangChiTiet> donHangChiTiets { get; set; }
        public DonHang()
        {
            donHangChiTiets = new List<DonHangChiTiet>();
        }
    }
}
