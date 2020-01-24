using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Minesweeper.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View("Register");
        }//end Index

        [HttpPost]
        public ActionResult Register()
        { 
            return View("Home");
        }//end Register
    }//end class controller
}//end namespace