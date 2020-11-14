using System;
using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CSharp
{
    public abstract class Content : Entity<int> //内容
    {

        //Content中的createTime，不能被子类使用，但只读属性PublishTime使用它为外部提供内容的发布时间


        //一篇文章可以有多个评论
        //每个文章和评论都有一个评价


        public IList<Comment> Comments;
        public IList<Keyword> keywords;
        public Appraise Appraise;


        public User Author { get; set; }
        public string Title { get; set; }

        public string Body { get; set; }

        protected private string kind;
        public DateTime CreateTime { get; private set; }


        public DateTime PublishTime { get; protected set; }



        protected private Content(string kind)
        {
            CreateTime = DateTime.Now;
            this.kind = kind;
        }

        virtual public void Publish()
        {

        }









    }
}
