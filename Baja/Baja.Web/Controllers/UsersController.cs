﻿using Baja.Domain.User;
using Baja.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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


            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var role in db.Roles)
            {
                list.Add(new SelectListItem() { Value = role.Name, Text = role.Name });
            }
            ViewBag.Roles = list;

            UserViewModel user = new UserViewModel();
            user.UserId = appUser.Id;
            user.UserName = appUser.UserName;
            user.Email = appUser.Email;

            return View(user);
        }



        [HttpPost]
        public ActionResult Edit(UserViewModel editUser)
        {
            if (ModelState.IsValid)
            {
                // Manager Enabled \\
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                manager.UserValidator = new UserValidator<ApplicationUser>(manager);

                var user = manager.FindByEmail(editUser.Email);
                user.UserName = editUser.UserName;

                //If Choose A Role \\
                if(editUser.RoleName != null)
                {                   
                    foreach (var role in manager.GetRoles(user.Id))
                    {
                        manager.RemoveFromRole(editUser.UserId, role);
                    }
                    manager.AddToRole(user.Id, editUser.RoleName);
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(editUser);
        }

    }
}