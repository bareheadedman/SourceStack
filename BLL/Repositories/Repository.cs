﻿using System;
using System.Collections.Generic;
using BLL.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace BLL.Repositories
{
    public class Repository<T> where T : BaseEntity, new()
    {
        public SqlDbContext context;
        private DbSet<T> dbset;
        public Repository(SqlDbContext context)
        {
            this.context = context;
        }


        /// <summary>
        /// 保存实体entity到数据库
        /// </summary>
        /// <param name="entity">entity实体</param>
        /// <returns>返回保存到数据库实体的Id</returns>
        public int Save(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
            return entity.Id;


        }

        public void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }


        /// <summary>
        /// 通过Id找到用户
        /// </summary>
        /// <param name="Id"> 主键</param>
        /// <returns>返回查询的结果 如果没有就返回NULL</returns>
        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }


        /// <summary>
        /// 创建仅有一个Id的entity,它会被Attach,它不是真正的在数据库里面查找
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public T LoadProxy(int id)
        {
            T entity = new T { Id = id };
            dbset.Attach(entity);
            return entity;
        }





    }
}
