using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false)]
    class HelpMoneyChangedAttribute : Attribute
    {
        public HelpMoneyChangedAttribute()
        {

        }

        public int Amount { get; set; }
        public string Message { get; set; }
    }


}
