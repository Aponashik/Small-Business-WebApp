﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmallBusinessWebApp.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        public ActionResult Main_Index()
        {
            return View();
        }
    }
}