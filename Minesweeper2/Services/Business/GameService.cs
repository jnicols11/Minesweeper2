using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Minesweeper2.Models;
using Minesweeper2.Services.Utility;

namespace Minesweeper2.Services.Business
{
    public class GameService
    {
        public static BoardModel Board;
        private static MinesweeperLogger logger = MinesweeperLogger.GetInstance();

        public GameService(BoardModel board)
        {
            MinesweeperLogger.GetInstance().Info("Entering GameService.Gameservice()");
            Board = board;
            MinesweeperLogger.GetInstance().Info("Exiting GameService.Gameservice()");
        }//end Constructor

        public BoardModel Setup(string difficulty)
        {
            MinesweeperLogger.GetInstance().Info("Entering GameService.BoardModel()");
            int d;
            if (difficulty == "Easy")
            {
                d = 1;
            }//end if
            else if (difficulty == "Medium")
            {
                d = 2;
            }//end else if
            else
            {
                d = 3;
            }//end else

            Board.Difficulty = d;
            Board.setupLiveNeighbors();
            Board.calculateLiveNeighbors();
            Board.minesRemaining();
            MinesweeperLogger.GetInstance().Info("Exiting GameService.BoardModel()");
            return Board;
        }//end setDifficulty

        public void startTimer(BoardModel Board)
        {
            MinesweeperLogger.GetInstance().Info("Entering GameService.StartTimer()");
            Board.timer.Start();
            MinesweeperLogger.GetInstance().Info("Exiting GameService.StartTimer()");
        }//end startTimer

        public BoardModel Playgame(string cell)
        {
            MinesweeperLogger.GetInstance().Info("Entering GameService.Playgame()");
            CellModel Cell = new CellModel(0, 0, 0);
            for (int i = 0; i < Board.Size; i++)
            {
                for (int j = 0; j < Board.Size; j++)
                {
                    if (Board.theGrid[i, j].ID == Int32.Parse(cell))
                    {
                        Cell = Board.theGrid[i, j];
                    }//end if
                }//end nested for loop
            }//end for loop
            int row = Cell.RowNumber;
            int col = Cell.ColumnNumber;

            Board.theGrid[row, col].IsVisible = true;
            if (Board.theGrid[row, col].IsLive)
            {
                Board.resetLiveNeighbors();
                StopTimer();
                Board.loss = true;
                MinesweeperLogger.GetInstance().Info("Exiting GameService.Playgame()");
                return Board;
            }//end if
            else
            {
                Board.floodFill(row, col);
                Board.minesRemaining();
                MinesweeperLogger.GetInstance().Info("Exiting GameService.Playgame()");
                return Board;
            }//end else
        }//end Playgame

        public void StopTimer()
        {
            Board.timer.Stop();
        }//end StopTimer

        public bool CheckWin()
        {
            MinesweeperLogger.GetInstance().Info("Entering GameService.CheckWin()");
            if (Board.winCondition())
            {
                StopTimer();
                Board.score = Int32.Parse(Board.timer.ElapsedTicks.ToString());
                Board.resetLiveNeighbors();
                MinesweeperLogger.GetInstance().Info("Exiting GameService.CheckWin()");
                return true;
            }//end if
            else
            {
                MinesweeperLogger.GetInstance().Info("Exiting GameService.CheckWin()");
                return false;
            }//end else
        }//end CheckWin
    }//end GameService
}//end namespace