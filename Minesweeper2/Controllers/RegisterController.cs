using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Minesweeper2.Services.Business;
using Minesweeper2.Services.Data;
using Minesweeper2.Models;


namespace Minesweeper.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View("Register");
        }//end Index

        public ActionResult Register(UserModel user)
        {
            SecurityService ss = new SecurityService();
            Boolean success = ss.DoRegister(user);

            if (success)
            {
                return View("RegisterSuccess", user);
            }//end if
            else
            {
                return View("RegisterFailed");
            }//end else
        }//end Register
    }//end class controller
}//end namespace