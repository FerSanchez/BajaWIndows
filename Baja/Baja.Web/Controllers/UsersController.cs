using Baja.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Baja.Web.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        

        // GET: Users
        public ActionResult Index()
        {
            var users = db.Users;
            return View(users.ToList());
        }

        [HttpGet]
        public ActionResult Edit( string email)
        {
            // Manager Enabled \\
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            manager.UserValidator = new UserValidator<ApplicationUser>(manager);

            if (email == null)            
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            ApplicationUser appUser = new ApplicationUser();
            appUser = manager.FindByEmail(email);

            if (appUser == null) 
                return HttpNotFound();
            
            ViewBag.Name = new SelectList(db.Roles.ToList(), "Name", "Name");
            return View(appUser);
        }

    }
}