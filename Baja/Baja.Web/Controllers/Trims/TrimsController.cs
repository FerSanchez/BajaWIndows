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
using Baja.Domain.Fabric;
using System.IO;

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

            var Results = from b in db.Restrictions
                          select new
                          {
                              b.Id,
                              b.Name,
                              Checked = ((from ab in db.Trim_Restrictions
                                          where (ab.TrimId == id) && (ab.RestrictionsId == b.Id)
                                          select ab).Count() > 0)
                          };

            var MyViewModel = new TrimViewModel();
            MyViewModel.TrimId = id.Value;
            MyViewModel.Name = trim.Name;
            MyViewModel.ImageUrl = trim.ImageUrl;
            MyViewModel.Description = trim.Description;

           

            var MyCheckBoxList = new List<CheckBoxViewModel>();
            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { Id = item.Id, Name = item.Name, Checked = item.Checked });
            }

            MyViewModel.Restrictions = MyCheckBoxList;

            return View(MyViewModel);
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
        public ActionResult Create([Bind(Include = "Id,Name,Description,ImageUrl")] Trim trim, HttpPostedFileBase img)
        {//Agregar Imagen\\
            if (img != null)
            {
                var folder = Server.MapPath("~/Content/Trims/");
                var imageUrl = Path.GetFileName(img.FileName);
                var filename = Path.Combine(folder, imageUrl);
                img.SaveAs(filename);
                trim.ImageUrl = imageUrl;
            }
            else
            {
                trim.ImageUrl = "default.jpg";
            }


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

            var Results = from b in db.Restrictions
                          select new
                          {
                              b.Id,
                              b.Name,
                              Checked = ((from ab in db.Trim_Restrictions
                                          where (ab.TrimId == id ) && (ab.RestrictionsId == b.Id)
                                          select ab).Count() > 0)
                          };

            var MyViewModel = new TrimViewModel();
            MyViewModel.TrimId = id.Value;
            MyViewModel.Name = trim.Name;
            MyViewModel.ImageUrl = trim.ImageUrl;
            MyViewModel.Description = trim.Description;


            var MyCheckBoxList = new List<CheckBoxViewModel>();
            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { Id = item.Id, Name = item.Name, Checked = item.Checked });

            }

            MyViewModel.Restrictions = MyCheckBoxList;

            return View(MyViewModel);
        }

        // POST: Trims/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( TrimViewModel trim, HttpPostedFileBase img)
        {
            if (ModelState.IsValid)
            {

                var myTrim = db.Trims.Find(trim.TrimId);

                if (img != null)
                {
                    var folder = Server.MapPath("~/Content/Fabrics/");
                    var imageUrl = Path.GetFileName(img.FileName);
                    var filename = Path.Combine(folder, imageUrl);
                    img.SaveAs(filename);
                    myTrim.ImageUrl = imageUrl;

                }

                myTrim.Name = trim.Name;
                myTrim.Description = trim.Description;



                foreach (var item in db.Trim_Restrictions)
                {
                    if (item.TrimId == trim.TrimId)
                    {
                        db.Entry(item).State = EntityState.Deleted;
                    }
                }

                foreach (var item in trim.Restrictions)
                {
                    if (item.Checked)
                    {
                        db.Trim_Restrictions.Add(new Trim_Restrictions()
                        {
                            TrimId = trim.TrimId,
                            RestrictionsId = item.Id
                        });
                    }
                }

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
