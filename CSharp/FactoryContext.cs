using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    class FactoryContext
    {
        private static FactoryContext OnlyObject;

        private FactoryContext()
        {

        }

        public static FactoryContext GetFactoryContext()
        {
            if (OnlyObject == null)
            {
                OnlyObject = new FactoryContext();
                return OnlyObject;
            }
            return OnlyObject;
        }
        
    }
}
