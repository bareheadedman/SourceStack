using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{

    /// <summary>
    /// 求助
    /// </summary>
    public class Problem : Content
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 悬赏
        /// </summary>
        public int? Reward { get; set; }
        /// <summary>
        /// 求助的状态
        /// </summary>
        public ProblemStatus ProblemStatus { get; set; }
        /// <summary>
        /// 总结
        /// </summary>
        public Summary Summary { get; set; }
        /// <summary>
        /// 被评论
        /// </summary>
        public IList<Comment>? Comments;




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
