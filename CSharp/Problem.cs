using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public class Problem : Content
    {
        public string Title { get; set; }
        public int? Reward { get; set; }

        public ProblemStatus ProblemStatus { get; set; }

        public Summary Summary { get; set; }

        public IList<Comment<Problem>>? Comments;

        public void Load(int id)
        {

        }
        public void Delete(int id)
        {

        }
        public void repoistory()
        {

        }


        [HelpMoneyChanged(Amount = (-1)/*Reward*/, Message = "发布悬赏")]
        override public void Publish()
        {
            if (Author == null)
            {
                throw new ArgumentNullException("参数为空");
            }
            PublishTime = DateTime.Now;
            Author.HelpMoney -= Reward;
            Console.WriteLine("消耗悬赏的帮帮币");
        }




    }
}
