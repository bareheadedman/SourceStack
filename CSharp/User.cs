using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CSharp
{
    //Name（用户名）、Password（密码）和 邀请人（InvitedBy），和方法：Register()、Login()
    class User
    {
        public string Name;
        public string Password;
        public string InvitedBy;

        public bool Register(string name, string password,string invitedby, out string cause)
        {
            cause = "1";
            return false;
        }
    }
}
