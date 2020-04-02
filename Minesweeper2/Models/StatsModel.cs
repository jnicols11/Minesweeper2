using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minesweeper2.Models
{
    public class StatsModel
    {
        //initialize differnt stats users can achieve
        public double Time { get; set; }
        public double Score { get; set; }
        public string Username { get; set; }

        public StatsModel(double time, double score, string username)
        {
            this.Time = time;
            Score = score;
            Username = username;
        }//end StatsModel
    }//end StatsModel
}//end namespace