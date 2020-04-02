using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Web;

namespace Minesweeper2.Models
{
    [DataContract]
    public class UserModel
    {
        [Required]
        [DisplayName("FirstName")]
        [DefaultValue("")]
        [DataMember]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Lastname")]
        [DefaultValue("")]
        [DataMember]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Sex")]
        [DefaultValue("")]
        [DataMember]
        public string Sex { get; set; }

        [Required]
        [DisplayName("Age")]
        [DefaultValue("")]
        [DataMember]
        public int Age { get; set; }

        [Required]
        [DisplayName("State")]
        [DefaultValue("")]
        [DataMember]
        public string State { get; set; }

        [Required]
        [DisplayName("Email")]
        [DefaultValue("")]
        [DataMember]
        public string Email { get; set; }

        [Required]
        [DisplayName("Username")]
        [DefaultValue("")]
        [DataMember]
        public string Username { get; set; }

        [Required]
        [DisplayName("Password")]
        [DefaultValue("")]
        [DataMember]
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