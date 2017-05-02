using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Baja.Domain;
using Baja.Domain.Fabric;

namespace Baja.Web.Controllers
{
    public class FabricsController : Controller
    {
        private BajaDbContext db = new BajaDbContext();

        // GET: Fabrics
        public ActionResult Index()
        {
            var frabrics = db.Frabrics.Include(f => f.FabricBooks);
            return View(frabrics.ToList());
        }

        // GET: Fabrics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabric fabric = db.Frabrics.Find(id);
            if (fabric == null)
            {
                return HttpNotFound();
            }
            return View(fabric);
        }

        // GET: Fabrics/Create
        public ActionResult Create()
        {
            ViewBag.FabricBookId = new SelectList(db.FabricBooks, "Id", "Name");
            return View();
        }

        // POST: Fabrics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ImageUrl,FabricBookId")] Fabric fabric)
        {
            if (ModelState.IsValid)
            {
                db.Frabrics.Add(fabric);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FabricBookId = new SelectList(db.FabricBooks, "Id", "Name", fabric.FabricBookId);
            return View(fabric);
        }

        // GET: Fabrics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabric fabric = db.Frabrics.Find(id);
            if (fabric == null)
            {
                return HttpNotFound();
            }
            ViewBag.FabricBookId = new SelectList(db.FabricBooks, "Id", "Name", fabric.FabricBookId);
            return View(fabric);
        }

        // POST: Fabrics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ImageUrl,FabricBookId")] Fabric fabric)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fabric).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FabricBookId = new SelectList(db.FabricBooks, "Id", "Name", fabric.FabricBookId);
            return View(fabric);
        }

        // GET: Fabrics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fabric fabric = db.Frabrics.Find(id);
            if (fabric == null)
            {
                return HttpNotFound();
            }
            return View(fabric);
        }

        // POST: Fabrics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Fabric fabric = db.Frabrics.Find(id);
            db.Frabrics.Remove(fabric);
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
