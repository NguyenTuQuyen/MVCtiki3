using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _31161021458_NguyenTuQuyen.Models
{
    public class HoaDon
    {
        public HoaDon()
        {
            ChiTietHoaDons = new List<ChiTietHoaDon>();
        }
        [Key]
        public int MaHoaDon { get; set; }
        public IList<ChiTietHoaDon> ChiTietHoaDons
        {
            get;
            set;
        }
        public double TongTien { get; set; }
        public DateTime NgayLap { get; set; }
        public int? MaKhachHang { get; set; }
    }
}