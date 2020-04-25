using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Minesweeper2.Services.Business;
using Minesweeper2.Services.Data;
using Minesweeper2.Models;
using Minesweeper2.Services.Utility;

namespace Minesweeper.Controllers
{
    public class RegisterController : Controller
    {
        private static MinesweeperLogger logger = MinesweeperLogger.GetInstance();
        // GET: Register
        public ActionResult Index()
        {
            MinesweeperLogger.GetInstance().Info("Entering RegisterController.index()");
            MinesweeperLogger.GetInstance().Info("Exiitng RegisterController.index()");

            return View("Register");
        }//end Index

        public ActionResult Register(UserModel user)
        {
            MinesweeperLogger.GetInstance().Info("Entering RegisterController.Register()");
            
            SecurityService ss = new SecurityService();
            Boolean success = ss.DoRegister(user);

            if (success)
            {
                MinesweeperLogger.GetInstance().Info("Exiitng RegisterController.Resgister()");
                return View("RegisterSuccess", user);
            }//end if
            else
            {
                MinesweeperLogger.GetInstance().Info("Exiitng RegisterController.Register()");
                return View("RegisterFailed");
            }//end else
        }//end Register
    }//end class controller
}//end namespace