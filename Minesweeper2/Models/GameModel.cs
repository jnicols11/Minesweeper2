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

        public GameModel(int score, BoardModel gameboard, int timer, string difficulty)
        {
            Score = score;
            Gameboard = gameboard;
            Timer = timer;
            Difficulty = difficulty;
        }//end constructor
    }//end class
}//end namespace