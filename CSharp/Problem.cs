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

        public Problem() : base("求助")
        {
        }


        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 悬赏
        /// </summary>
        public int Reward { get; set; }
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
        public IList<Comment>? Comments { get; set; }
        /// <summary>
        /// 使用的那些关键字
        /// </summary>
        public IList<Keyword> Keywords { get; set; }

    }
}
