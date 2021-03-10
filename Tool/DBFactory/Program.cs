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




        }
    }
}
