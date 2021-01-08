using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    class ProblemRepository
    {
        SqlDbContext context;
        public ProblemRepository()
        {
            context = new SqlDbContext();
        }




        public void Publish(Problem problem)
        {
            if (problem.Author == null)
            {
                throw new ArgumentNullException("参数为空");
            }

            problem.PublishTime = DateTime.Now;

            //context.Add(problem);

            //context.Attach<User>(problem.Author);
            //problem.Author.HelpMoney.Surplus -= problem.Reward;
            context.SaveChanges();
            Console.WriteLine($"消耗悬赏{problem.Reward}帮帮币");
        }




    }
}
