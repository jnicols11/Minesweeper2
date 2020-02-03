using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Minesweeper2.Models;
using Minesweeper2.Services.Business;
using Minesweeper2.Services.Data;

namespace Minesweeper2.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index()
        {
            return View("Game");
        }//end Index

        public ActionResult OnButtonClick(GameModel game)
        {
            SecurityService ss = new SecurityService();
            SecurityDAO sd = new SecurityDAO();

            return View("Game");
        }//end  OnButtonClick
    }//end Controller
}//end namespace
