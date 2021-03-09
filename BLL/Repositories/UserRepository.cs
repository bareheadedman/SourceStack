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

        /// <summary>
        /// 找到以name开头的用户
        /// </summary>
        /// <param name="name">模糊查询以name为开头</param>
        /// <returns>返回查询到的所有用户，没有则返回NULL</returns>
        public IList<User> Selected(string name)
        {


            IList<User> users = (from u in context.Set<User>()
                                 where u.Name.StartsWith(name)
                                 select u
                                ).ToList();
            if (users.Count == 0)
            {
                return null;

            }

            return users;
        }


    }
}
