using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entities;
using BLL.Repositories;

namespace DBFactory
{
    class Program
    {
        static void Main(string[] args)
        {

            Helper.GetDbContext().Database.Delete();
            Helper.GetDbContext().Database.Create();

            UserFactory.Create();

            KeywordFactory.Create();

            User laowang = UserFactory.laowang;
            laowang.Keywords = new List<Keyword>();

            laowang.Keywords.Add(KeywordFactory.android);
            laowang.Keywords.Add(KeywordFactory.yuyan);



            Helper.GetDbContext().SaveChanges();

        }
    }
}
