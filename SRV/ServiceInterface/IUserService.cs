﻿using SRV.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRV.ServiceInterface
{
    public interface IUserService
    {
        /// <summary>
        ///  通过name找到实体entity返回model
        ///  </summary>
        /// <param name="invitedName">
        /// user的Name
        /// </param>
        /// <returns>返回找到后的entity没有则返回为NULL</returns>
        UserModel GetByName(string name);

        /// <summary>
        /// 查找是否存在name
        /// </summary>
        /// <param name="name">要查找的name</param>
        /// <returns>返回一个布尔值,如果存在则返回true,没有则返回false </returns>
        bool Exist(string name);

        /// <summary>
        /// 获取当前用户
        /// </summary>
        /// <returns>拿到当前用户转换成model</returns>
        UserModel GetCurrentUserAsModel();

        /// <summary>
        /// 保存eneity到数据库
        /// </summary>
        /// <param name="model">与eneity对应的model</param>
        /// <returns>返回保存后eneity的Id</returns>
        int Save(RegisterModel model);

        /// <summary>
        /// 查到以name开头或者等于name的用户
        /// </summary>
        /// <param name="name">要查找的字符串</param>
        /// <returns> 返回所有查出来的用户没有则返回NULL</returns>
        IList<UserModel> Selected(string name);

        /// <summary>
        /// 赋予注册时所需要的东西,并且持久化到数据库
        /// </summary>
        /// <param name="model">与eneity相对应的model</param>
        /// <returns> 返回持久化到数据库之后的Id</returns>    
        int Regisert(RegisterModel model);

        /// <summary>
        /// 保存用户上传的图片路径
        /// </summary>
        /// <param name="id">用户</param>
        /// <param name="iconPath">图片路径</param>
        void SaveIconPathToUser(int id, string iconPath);

    }
}
