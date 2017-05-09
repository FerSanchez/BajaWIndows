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
    public class FabricRestrictionsController : Controller
    {
        private BajaDbContext db = new BajaDbContext();

        // GET: FabricRestrictions
        public ActionResult Index()
        {
            return View(db.FabricRestrictions.ToList());
        }

        // GET: FabricRestrictions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FabricRestriction fabricRestriction = db.FabricRestrictions.Find(id);
            if (fabricRestriction == null)
            {
                return HttpNotFound();
            }
            return View(fabricRestriction);
        }

        // GET: FabricRestrictions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FabricRestrictions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] FabricRestriction fabricRestriction)
        {
            if (ModelState.IsValid)
            {
                db.FabricRestrictions.Add(fabricRestriction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fabricRestriction);
        }

        // GET: FabricRestrictions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FabricRestriction fabricRestriction = db.FabricRestrictions.Find(id);
            if (fabricRestriction == null)
            {
                return HttpNotFound();
            }
            return View(fabricRestriction);
        }

        // POST: FabricRestrictions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] FabricRestriction fabricRestriction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fabricRestriction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fabricRestriction);
        }

        // GET: FabricRestrictions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FabricRestriction fabricRestriction = db.FabricRestrictions.Find(id);
            if (fabricRestriction == null)
            {
                return HttpNotFound();
            }
            return View(fabricRestriction);
        }

        // POST: FabricRestrictions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FabricRestriction fabricRestriction = db.FabricRestrictions.Find(id);
            db.FabricRestrictions.Remove(fabricRestriction);
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
