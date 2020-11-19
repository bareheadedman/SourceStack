using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Suggest : Content, IAppraise
    {
        public string Title { get; set; }


        public Suggest() : base("suggest")
        {

        }

        public IList<Comment<Suggest>> Comments;
        public IList<Keyword<Suggest>> Keywords;
        public IList<Appraise> Appraises;
        override public void Publish()
        {
            if (Author == null)
            {
                throw new ArgumentNullException("参数为空");
            }
            PublishTime = DateTime.Now;
            Console.WriteLine("不消耗帮帮币");
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
