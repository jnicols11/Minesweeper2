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
        public int Difficulty { get; set; }

    }//end class
}//end namespace