using _31161021458_NguyenTuQuyen.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _31161021458_NguyenTuQuyen.Controllers
{
    public class HomeController : Controller
    {
        private MainDBContext db = new MainDBContext();
        public ActionResult Index()
        {
            
            return View(db.Products);

        }

        

      

    }
}