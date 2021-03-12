using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Text;

namespace BLL.Repositories
{

    public class SqlDbContext : DbContext
    {

        public SqlDbContext() : base("17Bang")
        {
            Database.Log = s => Debug.WriteLine(s);

            //Database.Log = Console.WriteLine; //打印Log在控制台 
            //Database.Log = s => Debug.Write(s);//打印Log在output/Debug窗口
            //Database.Log = s => File.AppendAllText("D:\\Debug\\EF6.txt", s); //Log记录到 D:\Debug\EF6.txt 文件下, 不写后缀名会自动添加文件


        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {




            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Keyword>().ToTable("Keywords");
            modelBuilder.Entity<Category>().ToTable("Categories");
            modelBuilder.Entity<HelpMoney>().ToTable("HelpMoneys");
            modelBuilder.Entity<Message>();
            modelBuilder.Entity<Content>();
            modelBuilder.Entity<Article>();
            modelBuilder.Entity<Problem>();
            modelBuilder.Entity<Suggest>();




            base.OnModelCreating(modelBuilder);
        }



    }

}
