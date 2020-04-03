using Minesweeper2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Minesweeper2.Services.Utility
{
    [DataContract]
    public class StatsDTO
    {
        [DataMember]
        public List<StatsModel> theStats { get; set; }
        [DataMember]
        public int MessageCode { get; set; }
        [DataMember]
        public string MessageText { get; set; }
    }//end StatsDTO
}//end namespace