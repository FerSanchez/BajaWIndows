using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Baja.Domain;
using Baja.Domain.Restriction;

namespace Baja.Web.Controllers
{
    public class RestrictionsController : Controller
    {
        private BajaDbContext db = new BajaDbContext();

        // GET: Restrictions
        public ActionResult Index()
        {
            return View(db.Restrictions.ToList());
        }

        // GET: Restrictions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restrictions restrictions = db.Restrictions.Find(id);
            if (restrictions == null)
            {
                return HttpNotFound();
            }
            return View(restrictions);
        }

        // GET: Restrictions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restrictions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Restrictions restrictions)
        {
            if (ModelState.IsValid)
            {
                db.Restrictions.Add(restrictions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restrictions);
        }

        // GET: Restrictions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restrictions restrictions = db.Restrictions.Find(id);
            if (restrictions == null)
            {
                return HttpNotFound();
            }
            return View(restrictions);
        }

        // POST: Restrictions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Restrictions restrictions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restrictions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restrictions);
        }

        // GET: Restrictions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restrictions restrictions = db.Restrictions.Find(id);
            if (restrictions == null)
            {
                return HttpNotFound();
            }
            return View(restrictions);
        }

        // POST: Restrictions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restrictions restrictions = db.Restrictions.Find(id);
            db.Restrictions.Remove(restrictions);
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
