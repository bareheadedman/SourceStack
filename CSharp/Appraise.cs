using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public class Appraise<T> : IAppraise<T> where T : Content
    {
        //每个文章和评论都有一个评价


        public User Author;
        public UpOrdown IsAgree;


        public void DisAgree(T refer)
        {
            this.Author.HelpPoint++;
            refer.Author.HelpPoint++;
            IsAgree = UpOrdown.Down;
        }

        public void Agree(T refer)
        {
            this.Author.HelpPoint++;
            refer.Author.HelpPoint++;
            IsAgree = UpOrdown.Up;
        }


    }

    public enum UpOrdown
    {
        Up,
        Down
    }


}
