﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Suggest : Content, IEstimate
    {




        public Suggest() : base("suggest")
        {

        }


        override public void Publish()
        {
            PublishTime = DateTime.Now;
            Console.WriteLine("不消耗帮帮币");
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