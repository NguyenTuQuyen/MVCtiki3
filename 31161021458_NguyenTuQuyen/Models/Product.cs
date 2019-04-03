using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _31161021458_NguyenTuQuyen.Models
{
    public partial class Product
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required]
        public string NameProduct { get; set; }

        [Display(Name = "Giá sản phẩm")]
        [Required]
        public string Price { get; set; }

        public string ImagePath { get; set; }


        [Display(Name = "Loại sản phẩm")]
        public string Category { get; set; }

        
        [ForeignKey("CategoryObj")]
        public int? CategoryProductID { get; set; }
        public virtual Category CategoryObj { get; set; }


        [Display(Name = "Giao nhanh")]
        public Boolean Ship24h { get; set; }

        [Display(Name = "Giảm giá")]
        public double Sale { get; set; }


        [Display(Name = "Đánh giá")]
        public double Rated { get; set; }

        [Display(Name = "Trả góp")]
        public Boolean Installment { get; set; }

        [Display(Name = "Mã khuyến mãi")]
        public String PromotionCode { get; set; }

        [Display(Name = "Tóm tắt tính năng")]
        public String Feature { get; set; }

        [Display(Name = "Mô tả sản phẩm")]
        public String Description { get; set; }

        [Display(Name = "Lượt mua")]
        public int Buyed { get; set; }


        

    }
}