using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public interface IAppraise<T> where T : Content
    {

        void Agree(T refer);

        void DisAgree(T refer);


    }
}
