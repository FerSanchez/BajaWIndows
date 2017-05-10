﻿using Baja.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Baja.Web.Controllers
{
   [Authorize(Roles = RoleNames.Administrator)]
    public class ControlPanelController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

       
    }
}
