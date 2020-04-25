using Minesweeper2.Models;
using Minesweeper2.Services.Data;
using Minesweeper2.Services.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Script.Serialization;

namespace Minesweeper2
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public StatsDTO GetAllStats()
        {
            StatsDTO statsDTO = new StatsDTO();
            List<StatsModel> theStats = new List<StatsModel>();
            theStats.Add(new StatsModel(45.22, 37.68, "infanu"));
            theStats.Add(new StatsModel(57.65, 68.34, "cyrusd"));

            statsDTO.theStats = theStats;
            statsDTO.MessageCode = 1;
            statsDTO.MessageText = "Stats for all players who have won the game.";

            return statsDTO;
        }//end GetAllStats
    }//end Service1
}//end namespace
