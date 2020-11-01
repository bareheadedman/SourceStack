using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public interface Iestimate
    {
        int Agree { get; set; }
        int Disagree { get; set; }

        void AgreeAdd(User Estimate);

        void DisagreeAdd(User Estimate);


    }
}
