using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Minesweeper2.Models
{
    public class UserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        public string State { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string encrypt(string str)
        {
            if(str == null)
            {
                return null;
            }//end if

            string _result = string.Empty;
            char[] temp = str.ToCharArray();
            foreach (var _singleChar in temp)
            {
                var i = (int)_singleChar;
                i = i - 2;
                _result += (char)i;
            }
            Password = _result;
            return _result;
        }//end encrypt

        public string decrypt(string str)
        {
            string _result = string.Empty;
            char[] temp = str.ToCharArray();
            foreach (var _singleChar in temp)
            {
                var i = (int)_singleChar;
                i = i + 2;
                _result += (char)i;
            }//end foreach
            Password = _result;
            return _result;
        }//end decrypt
    }//end class
}//end namespace