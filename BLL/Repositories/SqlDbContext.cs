using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Repositories
{
    class SqlDbContext : DbContext
    {


        public SqlDbContext() : base("17Bang")
        {

            Database.Log = Console.WriteLine; //打印Log在控制台

            //Database.Log = s => Debug.Write(s);//打印Log在output/Debug窗口
            //Database.Log = s => File.AppendAllText("D:\\Debug\\EF6.txt", s); //Log记录到 D:\Debug\EF6.txt 文件下, 不写后缀名会自动添加文件

        }




        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<Suggest> suggests { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<HelpMoney> HelpMoneys { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().ToTable("Users");


            base.OnModelCreating(modelBuilder);
        }



    }
}
