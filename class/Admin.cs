using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeck_CTDL_giai_thuat
{
    class Admin
    {
        //fields
        private string _user, _password;
        //constructor
        public Admin(string _admin, string _password)
        {
            this._user = _admin;
            this._password = _password;
        }
        //properties
        public string User
        {
            get
            {
                return _user;
            }

            set
            {
                _user = value;
            }
        }
        //properties
        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }
        //method
        public string toString()
        {
            return $"{_user,-10}{_password,-10}";
        }
    }
}
