using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class SqlDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectString =
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=18Bang;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            optionsBuilder
                .UseSqlServer(connectString)
                .EnableSensitiveDataLogging()
                .LogTo(

#if DEBUG
                (id, level) => level == Microsoft.Extensions.Logging.LogLevel.Debug,  //过滤条件 
                log => Console.WriteLine(log) //如何记录log
                );

#endif


#if PUBLISH

                (id, level) => level == Microsoft.Extensions.Logging.LogLevel.Warning,  //过滤条件 
                log => Console.WriteLine(log) //如何记录log
                );
#endif

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasCheckConstraint<Student>("CK_Age", "Age Between 0 AND 150 ")
                //.ToTable("TB_Student")
                .Property(m => m.Name)
                .HasMaxLength(64);

            modelBuilder.Entity<Student>()
                .Property(m => m.BeForm)
                .IsRequired();


            //modelBuilder.Entity<Major>()
            //.ToTable("TB_Major");





            //modelBuilder.Entity<Student>()
            //    .Ignore(m=>m.Age);


            //modelBuilder.Entity<Student>()
            //    .HasKey(s => new { s.Name, s.Age });

            //modelBuilder.Entity<Student>(s =>
            //{
            //    s.Property(s => s.Age)
            //        .HasMaxLength(50);
            //    s.Property(s => s.Name)
            //        .HasMaxLength(50);
            //});


            base.OnModelCreating(modelBuilder);
        }
    }
}
