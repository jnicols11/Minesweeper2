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

        public ActionResult Login(UserModel user)
        {
            SecurityService securityService = new SecurityService();
            Boolean success = securityService.Authenticate(user);

            if (success)
            {
                string username = user.Username;
                Session["user"] = username;
                return View("LoginSuccess", user);
            }//end if
            else
            {
                return View("LoginFailed");
            }//end else
        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            Session["difficulty"] = null;
            return View();
        }//end Logout
    }
}