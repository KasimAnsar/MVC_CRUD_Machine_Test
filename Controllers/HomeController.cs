using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MVC_CRUD_Machine_Test.Models;

namespace MVC_CRUD_Machine_Test.Controllers
{
    public class HomeController : Controller
    {
        ProductContext db = new ProductContext();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.products.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Products s)
        {
            if (ModelState.IsValid)
            {
                db.products.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(s);
        }

        public ActionResult Edit(int id)
        {
            var row = db.products.Where(x => x.ProductId == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(Products s)
        {
            if (ModelState.IsValid)
            {
                db.Entry(s).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(s);
        }


        public ActionResult Delete(int id)
        {
            var row = db.products.Where(x => x.ProductId == id).FirstOrDefault();
            return View(row);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductContext db = new ProductContext();
            Products s = db.products.Single(x => x.ProductId == id);
            db.products.Remove(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var DetailsById = db.products.Where(x => x.ProductId == id).FirstOrDefault();

            return View(DetailsById);
        }
    }
}



