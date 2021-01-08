﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace BLL.Entities
{
    /// <summary>
    /// 用户
    /// </summary>
    sealed public class User : BaseEntity
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 用户名密码
        /// </summary>
        public string Password { get; set; }
        //public TokenManager Tokens { get; set; }
        /// <summary>
        /// 帮帮币
        /// </summary>
        public HelpMoney HelpMoney { get; set; }
        /// <summary>
        /// 帮帮点
        /// </summary>
        public int? HelpPoint { get; set; }
        /// <summary>
        /// 帮帮豆
        /// </summary>
        public int? HelpBean { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 用户发布的文章
        /// </summary>
        public IList<Article> Articles { get; set; }
        /// <summary>
        /// 用户发布的求助
        /// </summary>
        public IList<Problem> Problems { get; set; }
        /// <summary>
        /// 用户发布的意见建议
        /// </summary>
        public IList<Suggest> Suggests { get; set; }
        /// <summary>
        /// 用户发布的系列分类
        /// </summary>
        public IList<Category> Categories { get; set; }






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



    }

}




