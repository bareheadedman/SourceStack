using CSharp._17bangTableAdapters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection;
using System.Security.Cryptography;
using System.Xml;
using System.Xml.Schema;
using static CSharp._17bang;

namespace CSharp
{
    public class Program
    {
        static void Main(string[] args)
        {

            SqlDbContext context = new SqlDbContext();

            //var db = context.Database;
            //db.Migrate();
            //db.EnsureDeleted();
            //db.EnsureCreated();



            //利用EF，插入3个User对象

            //User mbg = new User("马保国", "1234")
            //{
            //    CreateTime = DateTime.Now,
            //    Id=1
            //};

            //User mxg = new User("马大国", "1234")
            //{
            //    CreateTime = DateTime.Now,
            //    Id = 2
            //};

            //User mdg = new User("马小国", "1234")
            //{
            //    CreateTime = DateTime.Now,
            //    Id = 3
            //};
            //context.AddRange(mbg,mxg,mdg);



            //通过主键找到其中一个User对象

            //User user = context.Find<User>("马小国");


            //修改该User对象的Name属性，将其同步到数据库

            //User user = context.Find<User>("马小国");
            //user.Name = "小马国";

            //不加载User对象，仅凭其Id用一句Update SQL语句完成上题
            //User user = new User("马国国", "")
            //{
            //    Id = 3
            //};

            //context.Attach<User>(user);
            //user.HelpBean = 55;


            //删除该用户
            //context.Remove<User>(context.Find<User>("马小国"));


            context.SaveChanges();


        }
    }
}


