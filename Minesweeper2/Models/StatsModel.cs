using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Minesweeper2.Models
{
    [DataContract]
    public class StatsModel
    {
        //initialize differnt stats users can achieve
        [DataMember]
        public double Time { get; set; }

        [DataMember]
        public double Score { get; set; }

        [DataMember]
        public string Username { get; set; }

        public StatsModel(double time, double score, string username)
        {
            this.Time = time;
            Score = score;
            Username = username;
        }//end StatsModel
    }//end StatsModel
}//end namespace