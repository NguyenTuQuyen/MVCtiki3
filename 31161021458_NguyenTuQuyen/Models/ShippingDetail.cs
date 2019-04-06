using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _31161021458_NguyenTuQuyen.Models
{
    public class ShippingDetail
    {

        public int ID { get; set; }
        [Display(Name = "Họ tên:")]
        [Required]

        public string Name { get; set; }

        [Display(Name = "Điện thoại:")]
        [Required]
        public int Mobile { get; set; }

        [Display(Name = "Email:")]
        [EmailAddress]
      
        public string Email { get; set; }

        [Display(Name = "Tỉnh/Thành phố")]
        [Required]
      
        public string City { get; set; }


        [Display(Name = "Tên đường phố")]
        [Required]
       
        public string Road { get; set; }

        [Display(Name = "Địa chỉ chi tiết")]
        [Required]
        
        public string Address { get; set; }

        [Display(Name = "Lời nhắn")]
        
        public string Messages { get; set; }


        [Display(Name = "Sử dụng mã giảm giá:")]
        
        public String PromotionCodeInput { get; set; }
    }
}