using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Minesweeper2.Models;
using Minesweeper2.Services.Data;

namespace Minesweeper2.Services.Business
{
    public class SecurityService
    {
        public bool Authenticate(UserModel user)
        {
            SecurityDAO service = new SecurityDAO();
            return service.FindByUser(user);
        }//end Authenticate

        public bool DoRegister(UserModel user)
        {
            SecurityDAO service = new SecurityDAO();
            return service.RegisterData(user);
        }//end DoRegister
    }//end Security Service
}//end Namespace