﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Minesweeper2.Controllers
{
    public class StatsController : Controller
    {
        // GET: Stats
        public ActionResult Index()
        {
            return View();
        }//end Index
    }//end StatsController
}//end namespace