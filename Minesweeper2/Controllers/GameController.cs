using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.Mvc;
using Minesweeper2.Models;
using Minesweeper2.Services.Business;
using Minesweeper2.Services.Data;

namespace Minesweeper2.Controllers
{
    public class GameController : Controller
    {
        static BoardModel theBoard = new BoardModel(10);

        // GET: Game
        public ActionResult Index()
        {
            return View(theBoard);
        }//end Index

        public ActionResult Play(string difficulty)
        {
            GameService gs = new GameService(theBoard);
            Session["difficulty"] = difficulty;
            theBoard = gs.Setup(difficulty);
            gs.startTimer(theBoard);
            return View("Index", theBoard);
        }//end setDifficulty

        [HttpPost]
        public ActionResult OnButtonClick(string cell)
        {
            GameService gs = new GameService(theBoard);
            theBoard = gs.Playgame(cell);
            if(theBoard.loss == true)
            {
                Session["difficulty"] = null;
                theBoard.resetLiveNeighbors();
                return View("GameLoss", theBoard);
            }//end if

            if (gs.CheckWin()) 
            {
                Session["difficulty"] = null;
                theBoard.resetLiveNeighbors();
                return View("GameWin", theBoard);
            }//end if

            return PartialView("_Board", theBoard);
        }//end  OnButtonClick
    }//end Controller
}//end namespace
