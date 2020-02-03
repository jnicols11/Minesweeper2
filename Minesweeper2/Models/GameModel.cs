using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweeper2.Models
{
    public class GameModel
    {
        //Properties of the game (score, gameboard, timer, difficulty)
        public int Score { get; set; }
        public Board Gameboard { get; set; }
        public int Timer { get; set; }
        public int Difficulty { get; set; }

    }//end class
}//end namespace