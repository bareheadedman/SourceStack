﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace CSharp
{
    //注册/登录功能，定义一个User类，包含字段：Name（用户名）、Password（密码）和 邀请人（InvitedBy），和方法：Register()、Login()


    //    将之前User/Problem/HelpMoney类的字段封装成属性，其中：
    //user.Password在类的外部只能改不能读
    //如果user.Name为“admin”，输入时修改为“系统管理员”
    //problem.Reward不能为负数

    //每一个User对象一定有Name和Password赋值

    //让User类无法被继承


    //观察一起帮的求助（Problem）、文章（Article）和意见建议（Suggest），根据他们的特点，抽象出一个父类：内容（Content）

    sealed public class User : Entity<int>, ISendMessage, IChat
    {

        public string Name { get; set; }
        public string Password { get; private set; }
        //public TokenManager Tokens { get; set; }
        public int? HelpMoney { get; set; }
        public int? HelpPoint { get; set; }
        public int? HelpBean { get; set; }
        public int? FailedTry { get; set; }
        public DateTime CreateTime { get; set; }






        private User(string name)
        {
            Name = name;
        }

        public User(string name, string password)
            : this(name)
        {

            Password = password;
        }

        public bool PassWordHasAny(string passWord, string condition)
        {
            char[] temp = passWord.ToCharArray();

            for (int i = 0; i < temp.Length; i++)
            {
                if (condition.Contains(temp[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public bool PassWordCondition(string passWord)
        {
            return
            (

            PassWordHasAny(passWord, "abcdefghijklmnopqrstuvwxyz") &&
            PassWordHasAny(passWord, "ABCDEFGHIJKLMNOPQRSTUVWXYZ") &&
            PassWordHasAny(passWord, "0123456789") &&
            PassWordHasAny(passWord, "~!@#$%^&*()_+")

            );

        }


        public int GetCount(string container, string target)
        {


            //return Regex.Matches(container,target).Count;

            return container.Split(target).Length - 1;

        }

        public string mimicJoin(string splice, params string[] container)
        {
            string temp = null;

            for (int i = 0; i < container.Length; i++)
            {
                temp += container[i];
                if (i != container.Length - 1)
                {
                    temp += splice;
                }

            }

            return temp;
        }

        void ISendMessage.Send()
        {

        }

        void IChat.Send()
        {

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




