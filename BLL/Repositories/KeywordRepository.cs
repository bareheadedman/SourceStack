using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repositories
{
    public class KeywordRepository : Repository<Keyword>
    {
        public KeywordRepository(SqlDbContext context) : base(context)
        {

        }


        /// <summary>
        /// 通过Id找到相应的关键字
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>没有则返回Null</returns>
        public Keyword GetByName(string name)
        {

            return context.Set<Keyword>().Where(k => k.Name == name).SingleOrDefault();
        }

        /// <summary>
        /// 找到当前等级的所有关键字
        /// </summary>
        /// <param name="level">等级</param>
        /// <returns>没有则返回null</returns>
        public IList<Keyword> GetByLevel(int level)
        {
            return context.Set<Keyword>().Where(k => k.Level == level).ToList();
        }

        /// <summary>
        /// 查到当前关键字的下一级所有关键字
        /// </summary>
        /// <param name="name">当前关键字name</param>
        /// <returns>没有则返回null</returns>
        public IList<Keyword> GetByDownLevel(string name)
        {
            return context.Set<Keyword>().Where(k => k.UpLevel.Name == name).ToList();
        }

    }
}

