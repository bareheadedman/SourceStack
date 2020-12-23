using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public class Blog : Content
    {
        public string Sites { get; set; }

        public Blog() : base("Blog")
        {

        }
    }
}
