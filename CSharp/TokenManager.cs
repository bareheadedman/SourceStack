using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public class TokenManager
    {
        private Token _tokens = 0;
        public Token Tokens { get; private set; }


        public void Add(Token authority)
        {
            if ((Tokens & authority) == authority)
            {
                return;
            }
            else
            {
                Tokens = Tokens | authority;
            }
        }

        public void Remove(Token authority)
        {
            if ((Tokens & authority) == authority)
            {
                Tokens = Tokens ^ authority;
            }
            else
            {
                return;
            }

        }


        public bool Has(Token authority)
        {
            return ((Tokens & authority) == authority);
        }

    }
}
