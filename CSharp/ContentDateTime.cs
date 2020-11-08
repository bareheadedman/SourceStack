using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CSharp
{
    class ContentDateTime
    {
        public void AlteCreateTime(Content content, DateTime datetime)
        {

            typeof(Content)
             .GetProperty("CreateTime", BindingFlags.Public | BindingFlags.Instance)
             .SetValue(content, datetime);

        }


        public void AlterPublishTime(Content content, DateTime dateTime)
        {
            typeof(Content)
             .GetProperty("PublishTime", BindingFlags.Public | BindingFlags.Instance)
             .SetValue(content, dateTime);


        }
    }
}
