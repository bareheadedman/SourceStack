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
        public string InvitedBy;
        public string InvitedCode;

        public bool Register(string invitedby, string invitedCode, string name, string password, string repeatPassword, string securityCode, out string cause)
        {
            if (invitedby.Length > 0)
            {
                if (invitedCode.Length == 4 && int.TryParse(invitedCode, out int a))
                {
                    if (invitedCode == "1234")
                    {
                        if (name.Length > 0)
                        {
                            if (name != "jkl123")
                            {
                                if (password.Length > 0)
                                {
                                    if (password.Length < 4 && password.Length > 20)
                                    {
                                        if (repeatPassword.Length > 0)
                                        {
                                            if (repeatPassword == password)
                                            {
                                                if (securityCode.Length > 0)
                                                {
                                                    if (securityCode.Length == 4)
                                                    {
                                                        if (securityCode == "jk12")
                                                        {
                                                            cause = "注册成功";
                                                            return true;
                                                        }
                                                        else
                                                        {
                                                            cause = "验证码错误";
                                                            return false;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        cause = "验证码的长度只能等于4";
                                                        return false;
                                                    }
                                                }
                                                else
                                                {
                                                    cause = "验证码不能为空";
                                                    return false;
                                                }
                                            }
                                            else
                                            {
                                                cause = "确认密码和密码不一致";
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            cause = "确认密码不能为空";
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        cause = "密码长度不能小于4，大于20";
                                        return false;
                                    }
                                }
                                else
                                {
                                    cause = "密码不能为空";
                                    return false;
                                }
                            }
                            else
                            {
                                cause = "用户名已存在";
                                return false;
                            }
                        }
                        else
                        {
                            cause = "用户名不能为空";
                            return false;
                        }
                    }
                    else
                    {
                        cause = "邀请码错误";
                        return false;
                    }
                }
                else
                {
                    cause = "邀请码只能是4位数字";
                    return false;
                }
            }
            else
            {
                cause = "邀请人不能为空";
                return false;
            }

        }

        public bool Login(string name, string password,string securityCode, out string cause)
        {
            if (name.Length > 0)
            {
                if (name == "jk123")
                {
                    if (password.Length >= 4 && password.Length <= 20)
                    {
                        if (password == "jk789")
                        {
                            if (securityCode.Length>0)
                            {
                                if (securityCode.Length ==4)
                                {
                                    if (securityCode=="jk85")
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
                                else
                                {
                                    cause = "验证码的长度只能等于4";
                                    return false;
                                }
                            }
                            else
                            {
                                cause = "验证码不能为空";
                                return false;
                            }
                        }
                        else
                        {
                            cause = "用户名或密码错误";
                            return false;
                        }
                    }
                    else
                    {
                        cause = "密码的长度不能小于4，大于20";
                        return false;
                    }
                }
                else
                {
                    cause = "用户名不存在";
                    return false;
                }
            }
            else
            {
                cause = "用户名不能为空";
                return false;
            }
        }


    }
}
