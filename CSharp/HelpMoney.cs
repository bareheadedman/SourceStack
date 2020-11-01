using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    //帮帮币版块，定义一个类HelpMoney，表示一行帮帮币交易数据，包含你认为应该包含的字段和方法

    public class HelpMoney:Entity
    {
        public DateTime Time;



        public int Usable;
        public int NotAvailable;
        public string Kind;
        public int Variation;
        public string Explain;
        public string User;

        public void Get(HelpMoney Helpmoney)
        {
            Console.WriteLine("");
        }



    }
}
