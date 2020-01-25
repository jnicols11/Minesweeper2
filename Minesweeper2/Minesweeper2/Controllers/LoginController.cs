using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Minesweeper2.Models;
using Minesweeper2.Services.Business;


namespace Minesweeper2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View("Login");
        }
<<<<<<< HEAD
        [HttpPost]
        public ActionResult Login()
        {
            SecurityService ss = new SecurityService();
            SecurityDAO sd = new SecurityDAO();
            return View("Home");
=======

        public ActionResult Login(UserModel user)
        {
            SecurityService securityService = new SecurityService();
            Boolean success = securityService.Authenticate(user);

            if (success)
            {
                return View("LoginSuccess", user);
            }//end if
            else
            {
                return View("LoginFailed");
            }//end else
>>>>>>> 18603d9d2e422af523d5ec52655fe878aee5e8f3
        }
    }
}