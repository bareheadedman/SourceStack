using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities
{

    /// <summary>
    /// 意见建议
    /// </summary>
    public class Suggest : Content, IAppraise
    {

        public Suggest() : base("意见建议")
        {

        }

        

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }



        //public IList<Comment<Suggest>> Comments;
        //public IList<Keyword<Suggest>> Keywords;
        //public IList<Appraise> Appraises;

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
