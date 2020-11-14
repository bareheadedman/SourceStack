using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public class Entity<T>
    {

        private T _Id;

        public T id
        {
            get
            {
                return _Id;
            }
        }


        protected private Entity()
        {

        }







    }
}
