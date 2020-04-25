using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Minesweeper2.Models;
using Minesweeper2.Services.Business;
using Minesweeper2.Services.Utility;

namespace Minesweeper2.Controllers
{
    public class LoginController : Controller
    {
        private static MinesweeperLogger logger = MinesweeperLogger.GetInstance();
        // GET: Login
        public ActionResult Index()
        {
            MinesweeperLogger.GetInstance().Info("Entering LoginController.index()");
            MinesweeperLogger.GetInstance().Info("Exiting LoginController.index()");
            return View("Login");
        }

        public ActionResult Login(UserModel user)
        {
            MinesweeperLogger.GetInstance().Info("Entering LoginController.login()");
            SecurityService securityService = new SecurityService();
            Boolean success = securityService.Authenticate(user);

            if (success)
            {
                string username = user.Username;
                Session["user"] = username;
                MinesweeperLogger.GetInstance().Info("Exiting LoginController.login()");
                return View("LoginSuccess", user);
            }//end if
            else
            {
                MinesweeperLogger.GetInstance().Info("Exiting LoginController.login()");
                return View("LoginFailed");
            }//end else
        }

        public ActionResult Logout()
        {
            MinesweeperLogger.GetInstance().Info("Entering LoginController.logout()");
            Session["user"] = null;
            Session["difficulty"] = null;
            MinesweeperLogger.GetInstance().Info("Exiting LoginController.logout()");
            return View();
        }//end Logout
    }//end Login Controller
}//end namespace