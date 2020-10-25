using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CSharp
{
    //Name（用户名）、Password（密码）和 邀请人（InvitedBy），和方法：Register()、Login()
    public class User
    {
        public string Name;
        public string Password;
        public string RepeatPassword;
        public string InvitedBy;
        public string InvitedCode;
        public string SecurityCode;

        public bool Register(User user, out string cause)
        {
            if (user.InvitedBy.Length == 0)
            {
                cause = "邀请人不能为空";
                return false;
            }

            if (user.InvitedCode.Length != 4 || !(int.TryParse(user.InvitedCode, out int a)))
            {
                cause = "邀请码只能是4位数字";
                return false;
            }

            if (user.InvitedCode != "1234")
            {
                cause = "邀请码错误";
                return false;
            }
            if (user.Name.Length == 0)
            {
                cause = "用户名不能为空";
                return false;
            }
            if (user.Name == "jkl123")
            {
                cause = "用户名已存在";
                return false;
            }
            if (user.Password.Length == 0)
            {
                cause = "密码不能为空";
                return false;
            }
            if (user.Password.Length > 4 || user.Password.Length > 20)
            {
                cause = "密码长度不能小于4，大于20";
                return false;
            }
            if (user.RepeatPassword.Length == 0)
            {
                cause = "确认密码不能为空";
                return false;
            }
            if (user.RepeatPassword != user.Password)
            {
                cause = "确认密码和密码不一致";
                return false;
            }
            if (user.SecurityCode.Length > 0)
            {
                cause = "验证码不能为空";
                return false;
            }
            if (user.SecurityCode.Length != 4)
            {
                cause = "验证码的长度只能等于4";
                return false;
            }
            if (user.SecurityCode == "jk12")
            {


                User consumer = new User();
                consumer.Name = user.Name;
                consumer.Password = user.Password;
                consumer.InvitedBy = user.InvitedBy;
                cause = "注册成功";
                return true;
            }
            else
            {
                cause = "验证码错误";
                return false;
            }




        }


        public bool Login(User user, out string cause)
        {
            if (user.Name.Length == 0)
            {
                cause = "用户名不能为空";
                return false;
            }
            if (user.Name != "jk123")
            {
                cause = "用户名不存在";
                return false;
            }
            if (user.Password.Length < 4 || user.Password.Length > 20)
            {
                cause = "密码的长度不能小于4，大于20";
                return false;
            }
            if (user.Password != "jk789")
            {
                cause = "用户名或密码错误";
                return false;
            }
            if (user.SecurityCode.Length > 0)
            {
                cause = "验证码不能为空";
                return false;
            }
            if (user.SecurityCode.Length != 4)
            {
                cause = "验证码的长度只能等于4";
                return false;
            }
            if (user.SecurityCode == "jk85")
            {
                cause = "登录成功";
                return true;
            }
            else
            {
                cause = "验证码错误";
                return false;


            }
        }

    }

}




