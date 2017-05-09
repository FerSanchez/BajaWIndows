using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Baja.Domain;
using Baja.Domain.Fabric;

namespace Baja.Web.Controllers
{
    public class FabricBooksController : Controller
    {
        private BajaDbContext db = new BajaDbContext();

        // GET: FabricBooks
        public ActionResult Index()
        {
     
            return View();
        }

        public ActionResult GetBooks()
        {
            var tblBooks = db.FabricBooks.Include(f => f.FabricCategories);
            return Json(tblBooks.ToList(),JsonRequestBehavior.AllowGet);
        }

        public ActionResult Get(int id)
        {
            var book = db.FabricBooks.ToList().Find(x => x.Id == id);
            return Json(book, JsonRequestBehavior.AllowGet);
        }



        // GET: FabricBooks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FabricBook fabricBook = db.FabricBooks.Find(id);
            if (fabricBook == null)
            {
                return HttpNotFound();
            }
            return View(fabricBook);
        }

        // GET: FabricBooks/Create
        public ActionResult Create()
        {
            ViewBag.FabricCategoryId = new SelectList(db.FabricCategories, "Id", "Name");
            return View();
        }

        // POST: FabricBooks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,FabricCategoryId")] FabricBook fabricBook)
        {

            if (ModelState.IsValid)
            {
                db.FabricBooks.Add(fabricBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FabricCategoryId = new SelectList(db.FabricCategories, "Id", "Name", fabricBook.FabricCategoryId);
            return View(fabricBook);
        }

        // GET: FabricBooks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FabricBook fabricBook = db.FabricBooks.Find(id);
            if (fabricBook == null)
            {
                return RedirectToAction("NotFound");
            }
            ViewBag.FabricCategoryId = new SelectList(db.FabricCategories, "Id", "Name", fabricBook.FabricCategoryId);
            return View(fabricBook);
        }

        public ActionResult NotFound()
        {
            return View();
        }


        // POST: FabricBooks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,FabricCategoryId")] FabricBook fabricBook)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fabricBook).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FabricCategoryId = new SelectList(db.FabricCategories, "Id", "Name", fabricBook.FabricCategoryId);
            return View(fabricBook);
        }

        // GET: FabricBooks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FabricBook fabricBook = db.FabricBooks.Find(id);
            if (fabricBook == null)
            {
                return HttpNotFound();
            }
            return View(fabricBook);
        }



        // POST: FabricBooks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FabricBook fabricBook = db.FabricBooks.Find(id);
            db.FabricBooks.Remove(fabricBook);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //    var fabricbooks = db.FabricBooks.Find(id);
        //    if (fabricbooks == null) return HttpNotFound();

        //    db.FabricBooks.Remove(fabricbooks);
        //    db.SaveChanges();

        //    if (Request.IsAjaxRequest())
        //    {
        //        return Json(new { success = true });
        //    }

        //    return RedirectToAction("Index");
        //}


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
