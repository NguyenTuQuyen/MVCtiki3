using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using _31161021458_NguyenTuQuyen.Models;

namespace _31161021458_NguyenTuQuyen.Controllers
{
    public class ProductsController : Controller
    {
        private MainDBContext db = new MainDBContext();

        // GET: Products
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.ListCategory = db.Categories.
                 Select(x => new SelectListItem()
                 { Text = x.Name, Value = x.ID.ToString() })
                 .Distinct()
                 .ToList();
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                product.ImagePath = "~/Content/Images/ProductImages/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/Images/ProductImages/"), fileName);
                file.SaveAs(fileName);

                product.CategoryProductID = int.Parse(product.Category);
                db.Products.Add(product);
                        db.SaveChanges();
                  
                return RedirectToAction("Index");
            }
            ViewBag.ListCategory = db.Categories.
              Select(x => new SelectListItem()
              { Text = x.Name, Value = x.ID.ToString() })
              .Distinct()
              .ToList();

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NameProduct,Price,Picture,CategoryProductID,Ship24h,Sale,Comment,Installment,PromotionCode,Feature,Description")] Product product, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                product.ImagePath = "~/Content/Images/ProductImages/" + fileName;
                fileName = Path.Combine(Server.MapPath("~/Content/Images/ProductImages/"), fileName);
                file.SaveAs(fileName);

                product.CategoryProductID = int.Parse(product.Category);

                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ListCategory = db.Categories.
              Select(x => new SelectListItem()
              { Text = x.Name, Value = x.ID.ToString() })
              .Distinct()
              .ToList();

            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        //Add to cart
        public ActionResult AddToCart(int id)
        {
            //Kiem tra Id movie ton tai hay khong
            var product = db.Products.Where(x => x.ID == id).FirstOrDefault();
            if (product == null)
            {
                return RedirectToAction("Index");
            }
            var hoaDon = this.Session["HoaDon"] as HoaDon;
            if (hoaDon == null)
            {
                hoaDon = new HoaDon();
                hoaDon.NgayLap = DateTime.Now;
                hoaDon.ChiTietHoaDons = new List<ChiTietHoaDon>();
                this.Session["HoaDon"] = hoaDon;
                db.HoaDons.Add(hoaDon);
            }
            //Kiem tra don hang da co truoc do
            var chiTietHoaDon = hoaDon.ChiTietHoaDons.Where(x => x.ProductObj.ID == id).FirstOrDefault();
            if (chiTietHoaDon == null)
            {
                chiTietHoaDon = new ChiTietHoaDon();
                chiTietHoaDon.MaProduct = id;
                chiTietHoaDon.ProductObj = product;
                chiTietHoaDon.HoaDonObj = hoaDon;
                chiTietHoaDon.SoLuong = 1;
                hoaDon.ChiTietHoaDons.Add(chiTietHoaDon);
            }
            else
            {
                chiTietHoaDon.SoLuong++;
            }
            hoaDon.TongTien =
                (double)hoaDon.ChiTietHoaDons
                .Sum(x => x.SoLuong * x.ProductObj.Price);
            db.SaveChanges();
            return View(hoaDon);
        }
        //tang giam so luong
        public ActionResult TangSoLuong(int id)
        {
            //Kiem tra Id product ton tai hay khong

            var hoaDon = this.Session["HoaDon"] as HoaDon;

            //Kiem tra don hang da co truoc do
            var chiTietHoaDon = hoaDon.ChiTietHoaDons.Where(x => x.ProductObj.ID == id).FirstOrDefault();

            chiTietHoaDon.SoLuong++;

            hoaDon.TongTien =
                (double)hoaDon.ChiTietHoaDons
                .Sum(x => x.SoLuong * x.ProductObj.Price);
            db.SaveChanges();
            return View("AddToCart", hoaDon);
        }
        public ActionResult GiamSoLuong(int id)
        {
            //Kiem tra Id product ton tai hay khong

            var hoaDon = this.Session["HoaDon"] as HoaDon;

            //Kiem tra don hang da co truoc do
            var chiTietHoaDon = hoaDon.ChiTietHoaDons.Where(x => x.ProductObj.ID == id).FirstOrDefault();

            chiTietHoaDon.SoLuong--;

            hoaDon.TongTien =
                (double)hoaDon.ChiTietHoaDons
                .Sum(x => x.SoLuong * x.ProductObj.Price);
            db.SaveChanges();
            return View("AddToCart", hoaDon);
        }

        public ActionResult RemoveFromCart(int maMovies)
        {
            var hoaDon = this.Session["HoaDon"] as HoaDon;
            var chiTietHoaDon = hoaDon.ChiTietHoaDons.Where(x
            => x.ProductObj.ID == maMovies).FirstOrDefault();
            hoaDon.ChiTietHoaDons.Remove(chiTietHoaDon);
            return View("AddToCart", hoaDon);
        }

        public PartialViewResult Summary()
        {
            var hoaDon = this.Session["HoaDon"] as HoaDon;
            if (hoaDon == null)
            {
                return null;
            }
            return PartialView(hoaDon);
        }

        [Authorize]
        public ActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Checkout(ShippingDetail detail)
        {
            var hoaDon = this.Session["HoaDon"] as HoaDon;
            if (hoaDon.ChiTietHoaDons.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                StringBuilder body = new StringBuilder()
                .AppendLine("A new order has been submitted")
                .AppendLine("---")
                .AppendLine("Items:");
                foreach (var hoaDonChiTiet in hoaDon.ChiTietHoaDons)
                {
                    var subtotal = hoaDonChiTiet.ProductObj.Price * hoaDonChiTiet.SoLuong;
                    body.AppendFormat("{0} x {1} (subtotal: {2:c}", hoaDonChiTiet.SoLuong,
                    hoaDonChiTiet.ProductObj.NameProduct,
                    subtotal);
                }
                body.AppendFormat("Total order value: {0:c}", hoaDon.TongTien)
                .AppendLine("---")
                .AppendLine("Ship to:")
                .AppendLine(detail.Name)
                .AppendLine(detail.Address)
                .AppendLine(detail.Mobile.ToString());
                //EmailServiceNew.SendEmail(new IdentityMessage()
                //{
                //    Destination = detail.Email,
                //    Subject = "New order submitted!",
                //    Body = body.ToString()
                //});
                this.Session["HoaDon"] = null;
                return View("CheckoutCompleted");
            }
            else
            {
                return View(new ShippingDetail());
            }
        }
    }
}
