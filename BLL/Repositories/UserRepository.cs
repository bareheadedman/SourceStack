using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    class UserRepository
    {
        SqlDbContext context;
        public UserRepository()
        {
            context = new SqlDbContext();
        }


        /// <summary>
        /// 通过Id找到用户
        /// </summary>
        /// <param name="Id"> 主键</param>
        /// <returns>返回查询的结果 如果没有就返回NULL</returns>
        public User GetUserById(int id)
        {
            throw new NotImplementedException();
            //return context.Users.Include(u => u.HelpMoney).Where(u => u.Id == id).SingleOrDefault();
        }
        /// <summary>
        /// 通过name找到用户
        /// </summary>
        /// <param name="name">用户的用户名(唯一标识符,不可重复)</param>
        /// <returns> 返回查询的结果 没有则返回NULL</returns>
        public User GetUserByName(string name)
        {
            throw new NotImplementedException();
            //return context.Users.Where(u => u.Name == name).Include(u => u.HelpMoney).SingleOrDefault();
        }
        /// <summary>
        /// 保存改动
        /// </summary>
        public void Save()
        {
            context.SaveChanges();
        }

    }
}
