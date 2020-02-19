using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Minesweeper2.Models;

namespace Minesweeper2.Services.Business
{
    public class GameService
    {
        public static BoardModel Board;

        public GameService(BoardModel board)
        {
            Board = board;
        }//end Constructor

        public BoardModel Setup(string difficulty)
        {
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
            return Board;
        }//end setDifficulty

        public void startTimer(BoardModel Board)
        {
            Board.timer.Start();
        }//end startTimer

        public BoardModel Playgame(string cell)
        {
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
                return Board;
            }//end if
            else
            {
                Board.floodFill(row, col);
                Board.minesRemaining();
                return Board;
            }//end else
        }//end Playgame

        public void StopTimer()
        {
            Board.timer.Stop();
        }//end StopTimer

        public bool CheckWin()
        {
            if (Board.winCondition())
            {
                StopTimer();
                Board.score = Double.Parse(Board.timer.ElapsedTicks.ToString());
                Board.resetLiveNeighbors();
                return true;
            }//end if
            else
            {
                return false;
            }//end else
        }//end CheckWin
    }//end GameService
}//end namespace