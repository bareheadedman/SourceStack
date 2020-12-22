using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class Message
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Content { get; set; }
        public bool HasRead { get; set; }
        public MessageStatus MessageStatus { get; set; }


    }
}
