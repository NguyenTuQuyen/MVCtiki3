using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _31161021458_NguyenTuQuyen.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Tên danh muc")]
        [Required]
        [StringLength(1000)]
        public string Name { get; set; }

    }
    
}