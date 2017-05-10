using Baja.Domain.User;
using Baja.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Baja.Web.Controllers
{
    public class RoleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Role
        public ActionResult Index()
        {
            var roles = db.Roles.ToList();
            return View(roles);
        }
       
        // GET: Role/Create
        public ActionResult Create()
        {
            var role = new IdentityRole();
            return View(role);
        }

        // POST: Role/Create
        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            db.Roles.Add(role);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Role/Delete/5
        public ActionResult Delete(string name)
        {
            if (name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var role = db.Roles.Where(d => d.Name == name).FirstOrDefault();

            RoleViewModel roleViewModel = new RoleViewModel();
            roleViewModel.Id = role.Id;
            roleViewModel.Name = role.Name;

            if (role == null)
            {
                return HttpNotFound();
            }
            return View(roleViewModel);
        }

        // POST: Role/Delete/5
        [HttpPost]
        public ActionResult Delete(RoleViewModel roleViewModel)
        {
            var role = db.Roles.Where(d => d.Name == roleViewModel.Name).FirstOrDefault();
            db.Roles.Remove(role);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
