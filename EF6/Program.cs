using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6
{
    class Program
    {
        static void Main(string[] args)
        {
            createDb();

            //SqlDbContext context = new SqlDbContext();

            //string Query = "SELECT * FROM Users WHERE Id=@p0";
            //User u1 = context.Users.SqlQuery(Query, 1).SingleOrDefault();
            //Console.WriteLine(u1.Name);
            ////context.SaveChanges();

        }

        static void createDb()
        {
            SqlDbContext context = new SqlDbContext();

            context.Database.Delete();
            context.Database.Create();

        }

    }
}
