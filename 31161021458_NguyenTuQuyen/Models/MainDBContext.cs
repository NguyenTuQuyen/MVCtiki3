using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _31161021458_NguyenTuQuyen.Models
{
    public class MainDBContext : DbContext
    {
        public MainDBContext()
          : base("DefaultConnection")
        {
            Database.Log = s
                => System.Diagnostics.Debug.WriteLine(s);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}