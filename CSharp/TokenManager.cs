using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public class TokenManager
    {

        public Token Tokens { get; private set; }


        public void Add(Token authority)
        {
            if (!(Has(authority)))
            {
                Tokens = Tokens | authority;

            }
            else
            {
                //
            }
        }

        public void Remove(Token authority)
        {
            if (Has(authority))
            {
                Tokens = Tokens ^ authority;
            }
            else
            {
                //
            }

        }


        public bool Has(Token authority)
        {
            return ((Tokens & authority) == authority);
        }

    }
}
