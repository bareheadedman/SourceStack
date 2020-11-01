using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Suggest:Content,Iestimate
    {




        public Suggest():base("suggest")
        {

        }


      override  public  void Publish( )
        {
            Console.WriteLine("不消耗帮帮币");
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
