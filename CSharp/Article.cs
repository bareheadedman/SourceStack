using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{

    /// <summary>
    /// 文章
    /// </summary>
    public class Article : Content, IAppraise
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        public Category Category { get; set; }
        public IList<Comment> Comments { get; set; }
        public IList<Keyword> Keywords { get; set; }
        public IList<Appraise> AppraiseS { get; set; }




        [HelpMoneyChanged(Amount = (-1), Message = "发布文章")]
        override public void Publish()
        {
            if (Author == null)
            {
                throw new ArgumentNullException("参数为空");
            }
            PublishTime = DateTime.Now;
            Author.HelpMoney--;
            Console.WriteLine("消耗一个帮帮币");
        }

        public void AgreeBy(User vote)
        {
            this.Author.HelpPoint++;
            vote.HelpPoint++;
        }

        public void DisAgreeBy(User vote)
        {
            this.Author.HelpPoint++;
            vote.HelpPoint++;
        }

    }
}
