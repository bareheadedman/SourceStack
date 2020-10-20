using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    //标题（Title）、正文（Body）、悬赏（Reward）、发布时间（PublishDateTime）和作者（Author），和方法Publish()
    class Problem
    {
        public string Title;
        public string Body;
        public string Reward;
        public string PublicDateTime;
        public string Author;

        public bool Publish(string title,string body,int Reward,int publishdatetime,out string cause)
        {
            cause = "1";
            return false;
        }
    }
}
