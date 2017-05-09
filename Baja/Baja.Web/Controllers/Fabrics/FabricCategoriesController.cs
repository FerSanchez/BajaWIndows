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
            return View();
        }

        public ActionResult GetCategories()
        {
            var tblcategories = db.FabricCategories.ToList();
            return Json(tblcategories, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get(int id)
        {
            var categorie = db.FabricCategories.ToList().Find(x => x.Id == id);
            return Json(categorie, JsonRequestBehavior.AllowGet);
        }


        // POST: FabricCategories/Create
        [HttpPost]
        public ActionResult Create([Bind(Include  = "Id")] FabricCategory fabricCategory)
        {
            if (ModelState.IsValid)
            {
                db.FabricCategories.Add(fabricCategory);
                db.SaveChanges();
            }

            return Json(fabricCategory, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(FabricCategory fabricCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fabricCategory).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(fabricCategory, JsonRequestBehavior.AllowGet);
        }

        // GET: FabricCategories/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var fabricCategorie = db.FabricCategories.ToList().Find(x => x.Id == id);

            if (fabricCategorie != null)
            {
                db.FabricCategories.Remove(fabricCategorie);
                db.SaveChanges();
            }
            return Json(fabricCategorie, JsonRequestBehavior.AllowGet);
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
