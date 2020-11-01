using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    /*internal*/
    class Article : Content, Iestimate
    {



        public Article() : base("article")
        {

        }


        override public void Publish()
        {
            Author.HelpMoney--;
            Console.WriteLine("消耗一个帮帮币");
        }

        public int Agree { get; set; }

        public int Disagree { get; set; }

        public void DisagreeAdd(User Estimate)
        {
            Estimate.HelpPoint++;
            Author.HelpPoint++;
            Disagree++;
        }

        public void AgreeAdd(User Estimate)
        {
            Estimate.HelpPoint++;
            Author.HelpPoint++;
            Agree++;
        }

        
    }
}
