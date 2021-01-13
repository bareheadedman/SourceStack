using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Repositories
{
    class HelpMoneyRepository : Repository<HelpMoney>
    {
        public HelpMoneyRepository(SqlDbContext context) : base(context)
        {

        }
    }
}
