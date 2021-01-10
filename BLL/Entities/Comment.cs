using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities
{




    /// <summary>
    /// 评论
    /// </summary>
    public class Comment : Content
    {
 

        /// <summary>
        /// 内容
        /// </summary>
        public string Content;
        /// <summary>
        /// 评论的谁
        /// </summary>
        public Comment Refer;
        /// <summary>
        /// 评价
        /// </summary>
        public List<Appraise> Appraises;
        /// <summary>
        /// 被评论
        /// </summary>
        public IList<Comment> Comments;



    }
}
