using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Database_FirstApproach.Models;

namespace Database_FirstApproach.Controllers
{
    public class FirstApproachesController : Controller
    {
        private Database_FirstApproachEntities db = new Database_FirstApproachEntities();

        // GET: FirstApproaches
        public ActionResult Index()
        {
            return View(db.FirstApproaches.ToList());
        }

        // GET: FirstApproaches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FirstApproach firstApproach = db.FirstApproaches.Find(id);
            if (firstApproach == null)
            {
                return HttpNotFound();
            }
            return View(firstApproach);
        }

        // GET: FirstApproaches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FirstApproaches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Contact,City")] FirstApproach firstApproach)
        {
            if (ModelState.IsValid)
            {
                db.FirstApproaches.Add(firstApproach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(firstApproach);
        }

        // GET: FirstApproaches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FirstApproach firstApproach = db.FirstApproaches.Find(id);
            if (firstApproach == null)
            {
                return HttpNotFound();
            }
            return View(firstApproach);
        }

        // POST: FirstApproaches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Contact,City")] FirstApproach firstApproach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(firstApproach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(firstApproach);
        }

        // GET: FirstApproaches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FirstApproach firstApproach = db.FirstApproaches.Find(id);
            if (firstApproach == null)
            {
                return HttpNotFound();
            }
            return View(firstApproach);
        }

        // POST: FirstApproaches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FirstApproach firstApproach = db.FirstApproaches.Find(id);
            db.FirstApproaches.Remove(firstApproach);
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
