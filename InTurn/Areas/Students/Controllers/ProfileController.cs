﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InTurn.Areas.Students.Controllers
{
    [Authorize(Roles = "Admin,Student")]
    public class ProfileController : Controller
    {
        // GET: Students/Profile
        public ActionResult Index()
        {
            return View();
        }
    }
}