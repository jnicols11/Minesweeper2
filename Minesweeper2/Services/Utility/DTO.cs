using Minesweeper2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Minesweeper2.Services.Utility
{
    [DataContract]
    public class DTO
    {
        public DTO(int ErrorCode, string ErrorMsg, List<StatsModel> Stats)
        {
            this.ErrorCode = ErrorCode;
            this.ErrorMsg = ErrorMsg;
            this.Stats = Stats;
        }
        public DTO(int ErrorCode, string ErrorMsg, List<UserModel> Users)
        {
            this.ErrorCode = ErrorCode;
            this.ErrorMsg = ErrorMsg;
            this.Users = Users;
        }
        [DataMember]
        public int ErrorCode { get; set; }
        [DataMember]
        public string ErrorMsg { get; set; }
        [DataMember]
        public List<StatsModel> Stats { get; set; }

        [DataMember]
        public List<UserModel> Users { get; set; }
    }
}