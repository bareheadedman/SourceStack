using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public interface IAppraise 
    {

        void AgreeBy(User vote);

        void DisAgreeBy(User vote);


    }
}
