using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public class Keyword // 关键字
    {
        //        一篇文章可以有多个评论
        //一个评论必须有一个它所评论的文章
        //每个文章和评论都有一个评价
        //一篇文章可以有多个关键字，一个关键字可以对应多篇文章

        public string Word;

        public IList<Content> contents;


    }
}
