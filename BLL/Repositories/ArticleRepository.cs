using BLL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Repositories
{
    class ArticleRepository : Repository<Article>
    {

        public ArticleRepository(SqlDbContext context) : base(context)
        {

        }

    }
}
