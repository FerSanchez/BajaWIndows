using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Baja.Domain;
using Baja.Domain.Trim;

namespace Baja.Web.Controllers.Trims
{
    public class TrimsController : Controller
    {
        private BajaDbContext db = new BajaDbContext();

        // GET: Trims
        public ActionResult Index()
        {
            return View(db.Trims.ToList());
        }

        // GET: Trims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trim trim = db.Trims.Find(id);
            if (trim == null)
            {
                return HttpNotFound();
            }
            return View(trim);
        }

        // GET: Trims/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trims/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,ImageUrl")] Trim trim)
        {
            if (ModelState.IsValid)
            {
                db.Trims.Add(trim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trim);
        }

        // GET: Trims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trim trim = db.Trims.Find(id);
            if (trim == null)
            {
                return HttpNotFound();
            }
            return View(trim);
        }

        // POST: Trims/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,ImageUrl")] Trim trim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trim);
        }

        // GET: Trims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Trim trim = db.Trims.Find(id);
            if (trim == null)
            {
                return HttpNotFound();
            }
            return View(trim);
        }

        // POST: Trims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trim trim = db.Trims.Find(id);
            db.Trims.Remove(trim);
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
