using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{



    //一个评论必须有一个它所评论的文章
    //每个文章和评论都有一个评价



    public class Comment<T> : Content //评论
    {
        public string Content;
        public T Refer;
        public List<Appraise> Appraises;
        public IList<Comment<T>> Comments;

        public Comment() : base("comment")
        {
        }


    }
}
