using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{

    class Article : Content, IAppraise
    {


        //一篇文章可以有多个评论
        //每个文章和评论都有一个评价


        public IList<Comment<Article>> Comments;
        public IList<Keyword<Article>> Keywords;
        public IList<Appraise> AppraiseS;


        public string Title { get; set; }
        public Article target { get; set; }

        public Article() : base("article")
        {

        }


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
