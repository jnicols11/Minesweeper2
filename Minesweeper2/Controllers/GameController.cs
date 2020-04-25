using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Timers;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Minesweeper2.Models;
using Minesweeper2.Services.Business;
using Minesweeper2.Services.Data;
using Minesweeper2.Services.Utility;
using Newtonsoft.Json;
using Unity;
using Unity.Injection;

namespace Minesweeper2.Controllers
{
    public class GameController : Controller
    {
        //Create Unity Container for ioc
        UnityContainer container = new UnityContainer();

        // get instance of the logger
        private static MinesweeperLogger logger = MinesweeperLogger.GetInstance();
        static BoardModel theBoard = new BoardModel(10);

        // GET: Game
        public ActionResult Index()
        {
            return View(theBoard);
        }//end Index

        public ActionResult Play(string difficulty)
        {
            MinesweeperLogger.GetInstance().Info("Entering GameController.play()");
            GameService gs = new GameService(theBoard);
            Session["difficulty"] = difficulty;
            theBoard = gs.Setup(difficulty);
            gs.startTimer(theBoard);
            MinesweeperLogger.GetInstance().Info("Exiting GameController.play()");
            return View("Index", theBoard);
        }//end setDifficulty

        [HttpPost]
        public ActionResult OnButtonClick(string cell)
        {
            MinesweeperLogger.GetInstance().Info("Entering GameController.onButtonClick()");
            theBoard.score++;
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
                //create instance of securityDAO
                SecurityDAO sd = new SecurityDAO();

                //populate Stats model
                StatsModel sm = new StatsModel(theBoard.timer.Elapsed.Seconds, theBoard.score, Session["user"].ToString());

                
                //reset sessions and gameboard
                Session["difficulty"] = null;
                theBoard.resetLiveNeighbors();
                MinesweeperLogger.GetInstance().Info("Exitng GameController.onButtonClick()");
                return View("GameWin", theBoard);
            }//end if

            return PartialView("_Board", theBoard);
        }//end  OnButtonClick

        public ActionResult Pause()
        {
            BoardModel boards = theBoard.getTheBoard();
            cachePause(boards);
            return View("Index", theBoard);
        }

        public string cachePause(BoardModel board)
        {
            MinesweeperLogger.GetInstance().Info("Entering GameController.cachePause()");
            var cache = MemoryCache.Default;

            BoardModel boards = cache.Get("Board") as BoardModel;
            if (boards == null)
            {
                board.getTheBoard();
                var policy = new CacheItemPolicy().AbsoluteExpiration = DateTimeOffset.Now.AddDays(7);
                cache.Set("Board", board, policy);
            }
            else
            {
                board.setTheBoard(boards);
            }
            MinesweeperLogger.GetInstance().Info("Exiting GameController.cachePause()");
            return new JavaScriptSerializer().Serialize(board);
        }
        //end Pause
    }//end Controller
}//end namespace
