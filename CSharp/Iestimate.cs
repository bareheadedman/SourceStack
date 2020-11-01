using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public interface IEstimate
    {
        int AgreeAmount { get; set; }
        int DisagreeAmount { get; set; }

        void AgreeBy(User voter);

        void DisagreeBy(User voter);


    }
}
