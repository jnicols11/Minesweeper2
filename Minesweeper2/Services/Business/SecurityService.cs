using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Minesweeper2.Models;
using Minesweeper2.Services.Data;
using Minesweeper2.Services.Utility;

namespace Minesweeper2.Services.Business
{
    public class SecurityService
    {
        private static MinesweeperLogger logger = MinesweeperLogger.GetInstance();
        public bool Authenticate(UserModel user)
        {
            MinesweeperLogger.GetInstance().Info("Entering GameService.Authenticate()");
            SecurityDAO service = new SecurityDAO();
            MinesweeperLogger.GetInstance().Info("Exiting GameService.Authenticate()");
            return service.FindByUser(user);
        }//end Authenticate

        public bool DoRegister(UserModel user)
        {
            MinesweeperLogger.GetInstance().Info("Entering GameService.Authenticate()");
            SecurityDAO service = new SecurityDAO();
            MinesweeperLogger.GetInstance().Info("Exiting GameService.Authenticate()");
            return service.RegisterData(user);
        }//end DoRegister
    }//end Security Service
}//end Namespace