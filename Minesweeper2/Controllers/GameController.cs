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
        static BoardModel theBoard = new BoardModel(10);
        static GameModel theGame = new GameModel(theBoard);

        // GET: Game
        public ActionResult Index()
        {
            return View(theGame);
        }//end Index

        public ActionResult setDifficulty(string difficulty)
        {
            int d;
            if(difficulty == "Easy")
            {
                d = 1;
            }//end if
            else if(difficulty == "Medium")
            {
                d = 2;
            }//end else if
            else
            {
                d = 3;
            }//end else

            Session["difficulty"] = difficulty;
            theBoard.Difficulty = d;
            theBoard.setupLiveNeighbors();
            theBoard.calculateLiveNeighbors();
            return View("Index", theGame);
        }//end setDifficulty

        public ActionResult OnButtonClick(string r, string c)
        {
            int row = Int32.Parse(r);
            int col = Int32.Parse(c);
            if(theBoard.theGrid[row, col].IsLive)
            {
                return View("GameLoss");
            }//end if
            else
            {
                theBoard.floodFill(row, col);
            }//end else

            return View("Index", theGame);
        }//end  OnButtonClick
    }//end Controller
}//end namespace
