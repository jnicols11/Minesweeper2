using Minesweeper2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Minesweeper2.Controllers
{
    public class StatsController : Controller
    {
        [JsonProperty("stats")]
        public List<StatsModel> TheStats { get; set; }
        public int count { get; set; }
        // GET: Stats
        public ActionResult Index()
        {
            TheStats.Add(new StatsModel(26.54, 120, "infanu"));
            TheStats.Add(new StatsModel(56.40, 100, "infanu"));
            TheStats.Add(new StatsModel(36.42, 89, "cyrusd"));
            TheStats.Add(new StatsModel(72.69, 150, "cyrusd"));
            


            //populate list of stats

            return View("Stats");
        }//end Index
    }//end StatsController
}//end namespace