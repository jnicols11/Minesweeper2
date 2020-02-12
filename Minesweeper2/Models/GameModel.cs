using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweeper2.Models
{
    public class GameModel
    {
        //Properties of the game
        public int Score { get; set; }
        public BoardModel Gameboard { get; set; }
        public int Timer { get; set; }
        public string Difficulty { get; set; }
        public string[] Difficulties = new[] { "Easy", "Medium", "Hard" };

        public GameModel(BoardModel gameboard)
        {
            Gameboard = gameboard;
            Score = 0;
            Timer = 0;
        }//end constructor

        public GameModel()
        {
            Score = 0;
            Gameboard = new BoardModel(10);
            Timer = 0;
            Difficulty = "Easy";
        }//end default constructor
    }//end class
}//end namespace