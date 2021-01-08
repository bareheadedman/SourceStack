using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace EF6
{
    class SqlDbContext : DbContext
    {

        public SqlDbContext() : base("18Bang")
        {
            Database.Log = Console.WriteLine; //打印Log在控制台
            //Database.Log = s => Debug.Write(s);//打印Log在output/Debug窗口
            //Database.Log = s => File.AppendAllText("D:\\Debug\\EF6.txt", s); //Log记录到 D:\Debug\EF6.txt 文件下, 不写后缀名会自动添加文件

        }

        public DbSet<BaseEntity> BaseEntities { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Person>().ToTable("People");

            base.OnModelCreating(modelBuilder);
        }



    }
}
