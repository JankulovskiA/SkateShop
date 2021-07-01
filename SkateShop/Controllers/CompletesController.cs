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
    public class CompletesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Completes
        public ActionResult Index()
        {
            return View(db.Completes.ToList());
        }

        // GET: Completes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complete complete = db.Completes.Find(id);
            if (complete == null)
            {
                return HttpNotFound();
            }
            return View(complete);
        }

        // GET: Completes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Completes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,name,price,info,img")] Complete complete)
        {
            if (ModelState.IsValid)
            {
                db.Completes.Add(complete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(complete);
        }

        // GET: Completes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complete complete = db.Completes.Find(id);
            if (complete == null)
            {
                return HttpNotFound();
            }
            return View(complete);
        }

        // POST: Completes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,name,price,info,img")] Complete complete)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complete).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(complete);
        }

        // GET: Completes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complete complete = db.Completes.Find(id);
            if (complete == null)
            {
                return HttpNotFound();
            }
            return View(complete);
        }

        // POST: Completes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Complete complete = db.Completes.Find(id);
            db.Completes.Remove(complete);
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
