using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CSharp
{
    class DBMessage : ISendMessage
    {
        public void Send()
        {
            Console.WriteLine("发送消息");
        }
    }
}
