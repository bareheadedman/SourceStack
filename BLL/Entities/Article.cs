using System;
using System.Collections.Generic;
using System.Text;

namespace Entities

{

    /// <summary>
    /// 文章
    /// </summary>
    public class Article : Content, IAppraise
    {

        public Article() : base("文章")
        {
        }


        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 属于哪个系列分类
        /// </summary>
        public Category Category { get; set; }
        /// <summary>
        /// 有那些评论
        /// </summary>
        public IList<Comment> Comments { get; set; }
        /// <summary>
        /// 使用了那些关键字
        /// </summary>
        public IList<Keyword> Keywords { get; set; }
        /// <summary>
        /// 有那些评价
        /// </summary>
        public IList<Appraise> AppraiseS { get; set; }
        /// <summary>
        /// 文章的内容
        /// </summary>
        public string Body { get; set; }


        public void Publish()
        {

            if (Author == null)
            {
                throw new ArgumentNullException("参数为空");
            }
            PublishTime = DateTime.Now;
            Author.HelpMoney.Surplus--;
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
