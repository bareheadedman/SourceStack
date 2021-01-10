using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Repositories
{
    public class UserRepository : Repository<User>
    {

        public UserRepository(SqlDbContext context) : base(context)
        {

        }


        /// <summary>
        /// 通过name找到用户
        /// </summary>
        /// <param name="name">用户的用户名(唯一标识符,不可重复)</param>
        /// <returns> 返回查询的结果 没有则返回NULL</returns>
        public User GetByName(string name)
        {
            return context.Set<User>().Where(u => u.Name == name).SingleOrDefault();
        }


    }
}
