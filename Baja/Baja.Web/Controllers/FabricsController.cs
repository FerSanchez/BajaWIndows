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
using System.IO;

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

            //
            var Results = from b in db.FabricRestrictions
                          select new
                          {
                              b.Id,
                              b.Name,
                              Checked = ((from ab in db.Fabric_Restrictions
                                          where (ab.FabricId == id) && (ab.FabricRestrictionId == b.Id)
                                          select ab).Count() > 0)
                          };

            var MyViewModel = new FabricViewModel();
            MyViewModel.FabricId = id.Value;
            MyViewModel.Name = fabric.Name;
            MyViewModel.ImageUrl = fabric.ImageUrl;
            MyViewModel.FabricBookId = fabric.FabricBookId;


            FabricBook fb = db.FabricBooks.Find(MyViewModel.FabricBookId);
            if (fb == null)
            {

               return HttpNotFound();
           
            }
            else {

                MyViewModel.FabricBooks = new FabricBook()
                {
                    Id = fb.Id,
                    Name = fb.Name
                };

            }

            var MyCheckBoxList = new List<CheckBoxViewModel>();
            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { Id = item.Id, Name = item.Name, Checked = item.Checked });

            }

            MyViewModel.Restrictions = MyCheckBoxList;

            //

            ViewBag.FabricBookId = new SelectList(db.FabricBooks, "Id", "Name", fabric.FabricBookId);

            return View(MyViewModel);
        }


        // GET: Fabrics/Create
        public ActionResult Create()
        {

            ViewBag.RestrictionList = new MultiSelectList(db.FabricRestrictions, "Id", "Name");
            ViewBag.FabricBookId = new SelectList(db.FabricBooks, "Id", "Name");
            return View();
        }

        // POST: Fabrics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ImageUrl,FabricBookId")] Fabric fabric, HttpPostedFileBase img)
        {

            //Agregar Imagen\\
            if (img != null)
            {
                var folder = Server.MapPath("~/Content/Fabrics/");
                var imageUrl = Path.GetFileName(img.FileName);
                var filename = Path.Combine(folder, imageUrl);
                img.SaveAs(filename);
                fabric.ImageUrl = imageUrl;
            }
            else
            {
                fabric.ImageUrl = "null";
            }


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

            //
            var Results = from b in db.FabricRestrictions
                          select new
                          {
                              b.Id,
                              b.Name,
                              Checked = ((from ab in db.Fabric_Restrictions
                                          where (ab.FabricId == id) && (ab.FabricRestrictionId == b.Id)
                                          select ab).Count() > 0)
                          };

            var MyViewModel = new FabricViewModel();
            MyViewModel.FabricId = id.Value;
            MyViewModel.Name = fabric.Name;
            MyViewModel.ImageUrl = fabric.ImageUrl;
            MyViewModel.FabricBookId = fabric.FabricBookId;
            

            var MyCheckBoxList = new List<CheckBoxViewModel>();
            foreach (var item in Results)
            {
                MyCheckBoxList.Add(new CheckBoxViewModel { Id = item.Id, Name = item.Name, Checked = item.Checked });

            }

            MyViewModel.Restrictions = MyCheckBoxList;

            //

            ViewBag.FabricBookId = new SelectList(db.FabricBooks, "Id", "Name", fabric.FabricBookId);

            return View(MyViewModel);
        }

        // POST: Fabrics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FabricViewModel fabric )
        {
            if (ModelState.IsValid)
            {
                var myFabric = db.Frabrics.Find(fabric.FabricId);

                myFabric.Name = fabric.Name;
                myFabric.ImageUrl = fabric.ImageUrl;
                myFabric.FabricBookId = fabric.FabricBookId;

                foreach (var item in db.Fabric_Restrictions)
                {
                    if (item.FabricId == fabric.FabricId)
                    {
                        db.Entry(item).State = EntityState.Deleted;
                    }
                }

                foreach (var item in fabric.Restrictions)
                {
                    if (item.Checked)
                    {
                        db.Fabric_Restrictions.Add(new Fabric_Restriction()
                        {
                            FabricId = fabric.FabricId,
                            FabricRestrictionId = item.Id
                        });
                    }
                }

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
