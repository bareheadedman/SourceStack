using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Suggest : Content
    {
        public string Title { get; set; }


        public Suggest() : base("suggest")
        {

        }

        public IList<Comment<Suggest>> Comments;
        public IList<Keyword<Suggest>> Keywords;
        public Appraise<Suggest> Appraise;
        override public void Publish()
        {
            PublishTime = DateTime.Now;
            Console.WriteLine("不消耗帮帮币");
        }




    }
}
