﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    
    class Article : Content, IEstimate
    {



        public Article() : base("article")
        {

        }

        
        [HelpMoneyChanged(Amount =(-1),Message ="发布文章")]
        override public void Publish()
        {
            PublishTime = DateTime.Now;
            Author.HelpMoney--;
            Console.WriteLine("消耗一个帮帮币");
        }

        public int AgreeAmount { get; set; }

        public int DisagreeAmount { get; set; }

        public void DisagreeBy(User Estimate)
        {
            Estimate.HelpPoint++;
            Author.HelpPoint++;
            DisagreeAmount++;
        }

        public void AgreeBy(User Estimate)
        {
            Estimate.HelpPoint++;
            Author.HelpPoint++;
            AgreeAmount++;
        }


    }
}