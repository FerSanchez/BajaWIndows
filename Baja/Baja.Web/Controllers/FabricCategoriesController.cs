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
    public class FabricCategoriesController : Controller
    {
        private BajaDbContext db = new BajaDbContext();

        // GET: FabricCategories
        public ActionResult Index()
        {
            return View(db.FabricCategories.ToList());
        }

        // GET: FabricCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FabricCategory fabricCategory = db.FabricCategories.Find(id);
            if (fabricCategory == null)
            {
                return HttpNotFound();
            }
            return View(fabricCategory);
        }

        // GET: FabricCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FabricCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] FabricCategory fabricCategory)
        {
            if (ModelState.IsValid)
            {
                db.FabricCategories.Add(fabricCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fabricCategory);
        }

        // GET: FabricCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FabricCategory fabricCategory = db.FabricCategories.Find(id);
            if (fabricCategory == null)
            {
                return HttpNotFound();
            }
            return View(fabricCategory);
        }

        // POST: FabricCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] FabricCategory fabricCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fabricCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fabricCategory);
        }

        // GET: FabricCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FabricCategory fabricCategory = db.FabricCategories.Find(id);
            if (fabricCategory == null)
            {
                return HttpNotFound();
            }
            return View(fabricCategory);
        }

        // POST: FabricCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FabricCategory fabricCategory = db.FabricCategories.Find(id);
            db.FabricCategories.Remove(fabricCategory);
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
