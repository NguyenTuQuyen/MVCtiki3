using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _31161021458_NguyenTuQuyen.Models
{
    public class ChiTietHoaDon
    {
        [Key]
        public int MaChiTietHoaDon { get; set; }

        [ForeignKey("HoaDonObj")]
        public int MaHoaDon { get; set; }
        public virtual HoaDon HoaDonObj { get; set; }

        [ForeignKey("ProductObj")]
        public int MaProduct { get; set; }
        public virtual Product ProductObj { get; set; }

        public int SoLuong { get; set; }
    }
}