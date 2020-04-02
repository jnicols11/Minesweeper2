using Minesweeper2.Models;
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
        // GET: Stats
        public ActionResult Index()
        {
            List<StatsModel> TheStats = new List<StatsModel>();

            //deserialize json stats
            JavaScriptSerializer jss = new JavaScriptSerializer();

            //populate list of stats

            return View("Stats", TheStats);
        }//end Index
    }//end StatsController
}//end namespace