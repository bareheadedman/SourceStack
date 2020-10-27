using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CSharp
{
    //Name（用户名）、Password（密码）和 邀请人（InvitedBy），和方法：Register()、Login()
    sealed public class User
    {
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (value == "admin")
                {
                    Console.WriteLine("系统管理员");
                }
                _name = value;
            }
        }

        private string _password;

        public string Password
        {
            set
            {
                _password = value;
            }
        }


        private string _repeatPassword;
        private string _invitedBy;
        private string _invitedCode;
        private string _securityCode;




        private User()
        {

        }

        private User(string name)
        {
            Name = name;
        }

        public User(string name, string password)
            : this(name)
        {
            Password = password;
        }




        //public bool Register(User user, out string cause)
        //{
        //    if (user._invitedBy.Length == 0)
        //    {
        //        cause = "邀请人不能为空";
        //        return false;
        //    }

        //    if (user._invitedCode.Length != 4 || !(int.TryParse(user._invitedCode, out int a)))
        //    {
        //        cause = "邀请码只能是4位数字";
        //        return false;
        //    }

        //    if (user._invitedCode != "1234")
        //    {
        //        cause = "邀请码错误";
        //        return false;
        //    }
        //    if (user._name.Length == 0)
        //    {
        //        cause = "用户名不能为空";
        //        return false;
        //    }
        //    if (user._name == "jkl123")
        //    {
        //        cause = "用户名已存在";
        //        return false;
        //    }
        //    if (user.Password.Length == 0)
        //    {
        //        cause = "密码不能为空";
        //        return false;
        //    }
        //    if (user.Password.Length > 4 || user.Password.Length > 20)
        //    {
        //        cause = "密码长度不能小于4，大于20";
        //        return false;
        //    }
        //    if (user._repeatPassword.Length == 0)
        //    {
        //        cause = "确认密码不能为空";
        //        return false;
        //    }
        //    if (user._repeatPassword != user.Password)
        //    {
        //        cause = "确认密码和密码不一致";
        //        return false;
        //    }
        //    if (user._securityCode.Length > 0)
        //    {
        //        cause = "验证码不能为空";
        //        return false;
        //    }
        //    if (user._securityCode.Length != 4)
        //    {
        //        cause = "验证码的长度只能等于4";
        //        return false;
        //    }
        //    if (user._securityCode == "jk12")
        //    {


        //        User consumer = new User();
        //        consumer._name = user._name;
        //        consumer.Password = user.Password;
        //        consumer._invitedBy = user._invitedBy;
        //        cause = "注册成功";
        //        return true;
        //    }
        //    else
        //    {
        //        cause = "验证码错误";
        //        return false;
        //    }




        //}


        //public bool Login(User user, out string cause)
        //{
        //    if (user._name.Length == 0)
        //    {
        //        cause = "用户名不能为空";
        //        return false;
        //    }
        //    if (user._name != "jk123")
        //    {
        //        cause = "用户名不存在";
        //        return false;
        //    }
        //    if (user.Password.Length < 4 || user.Password.Length > 20)
        //    {
        //        cause = "密码的长度不能小于4，大于20";
        //        return false;
        //    }
        //    if (user.Password != "jk789")
        //    {
        //        cause = "用户名或密码错误";
        //        return false;
        //    }
        //    if (user._securityCode.Length > 0)
        //    {
        //        cause = "验证码不能为空";
        //        return false;
        //    }
        //    if (user._securityCode.Length != 4)
        //    {
        //        cause = "验证码的长度只能等于4";
        //        return false;
        //    }
        //    if (user._securityCode == "jk85")
        //    {
        //        cause = "登录成功";
        //        return true;
        //    }
        //    else
        //    {
        //        cause = "验证码错误";
        //        return false;


        //    }
        //}

    }

}




