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
            SecurityDAO sd = new SecurityDAO();

            List<StatsModel> theStats = sd.getAllStats();

            StatsDTO statsDTO = new StatsDTO();
            statsDTO.theStats = theStats;
            statsDTO.MessageCode = 1;
            statsDTO.MessageText = "Stats for all players who have won the game.";

            return statsDTO;
        }

        public string Pause(string Username)
        {
            throw new NotImplementedException();
        }

        public BoardModel Resume(string Username)
        {
            throw new NotImplementedException();
        }
        
    }//end Service1
}//end namespace
