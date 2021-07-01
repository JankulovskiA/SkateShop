using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SkateShop.Models;

namespace SkateShop.Controllers
{
    public class WheelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Wheels
        public ActionResult Index()
        {
            return View(db.Wheels.ToList());
        }

        // GET: Wheels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wheel wheel = db.Wheels.Find(id);
            if (wheel == null)
            {
                return HttpNotFound();
            }
            return View(wheel);
        }

        // GET: Wheels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Wheels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,price,img,info,sale")] Wheel wheel)
        {
            if (ModelState.IsValid)
            {
                db.Wheels.Add(wheel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(wheel);
        }

        // GET: Wheels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wheel wheel = db.Wheels.Find(id);
            if (wheel == null)
            {
                return HttpNotFound();
            }
            return View(wheel);
        }

        // POST: Wheels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,price,img,info,sale")] Wheel wheel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wheel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wheel);
        }

        // GET: Wheels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Wheel wheel = db.Wheels.Find(id);
            if (wheel == null)
            {
                return HttpNotFound();
            }
            return View(wheel);
        }

        // POST: Wheels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Wheel wheel = db.Wheels.Find(id);
            db.Wheels.Remove(wheel);
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
