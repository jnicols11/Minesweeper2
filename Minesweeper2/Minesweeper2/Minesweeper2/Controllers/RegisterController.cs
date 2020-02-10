using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Minesweeper2.Services.Business;
using Minesweeper2.Services.Data;


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
            SecurityService ss = new SecurityService();
            SecurityDAO sd = new SecurityDAO();
            return View("Home");
        }//end Register
    }//end class controller
}//end namespace