using BLL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFactory
{
    public class Helper
    {
        private static SqlDbContext _dbContext;

        static Helper()
        {
            _dbContext = new SqlDbContext();
        }

        public static SqlDbContext GetDbContext()
        {
            return _dbContext;
        }
    }
}
