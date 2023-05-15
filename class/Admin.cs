using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLThuVien
{
    class Admin
    {
        //fields
        private string _user, _password;
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
        //constructor day du
        public Admin(string _admin, string _password)
        {
            this._user = _admin;
            this._password = _password;
        }
        //constructor khong tham so
        public Admin()
        {

        }
        //method
        public string toString()
        {
            return $"{_user,-10}{_password,-10}";
        }
    }
}
