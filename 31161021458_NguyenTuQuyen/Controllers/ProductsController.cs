using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
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
    }
}
